using SurveysPortal.Modules.Surveys.Standard.Core.ValueObjects;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Entities;

public class StandardSurvey
{
    private List<StandardSurveyQuestion> _standardSurveyQuestions = new();
    private List<StandardSurveyUser> _standardSurveyParticipants = new();

    public StandardSurvey()
    {
    }

    public StandardSurvey
    (
        string name,
        string description,
        string introduction
    )
    {
        SetName(name);
        SetDescription(description);
        SetIntroduction(introduction);
        CreatedAt = DateTime.UtcNow;
    }

    public int Id { get; init; }
    public Guid UserId { get; init; }
    public SurveyName Name { get; set; }
    public string Description { get;  set; }
    public string Introduction { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; }

    public IReadOnlyCollection<StandardSurveyUser> StandardSurveyParticipants =>
        _standardSurveyParticipants.AsReadOnly();

    public IReadOnlyCollection<StandardSurveyQuestion> StandardSurveyQuestions => 
        _standardSurveyQuestions.AsReadOnly();
    public void SetName(string name)
    {
        Name = name;
        UpdateAt();
    }
    public void SetDescription(string description)
    {
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }
    public void SetIntroduction(string introduction)
    {
        Introduction = introduction;
        UpdatedAt = DateTime.UtcNow;
    }
    public void SetAsDeleted()
    {
        IsDeleted = true;
        UpdateAt();
    }
    public void SetQuestions(IList<StandardQuestionOrder> questions)
    {
        if (questions is null || !questions.Any())
        {
            throw new ArgumentNullException(nameof(questions),
                "Collection of questions must contain at least one question.");
        }

        _standardSurveyQuestions = questions.Select(x => new StandardSurveyQuestion(
                x.Question!,
                this,
                x.Index))
            .ToList();

        UpdatedAt = DateTime.UtcNow;
    }
    public IEnumerable<StandardQuestion> GetQuestions()
    {
        return _standardSurveyQuestions
            .OrderBy(x => x.StandardQuestionOrder)
            .Select(x => x.StandardQuestion);
    }
    public IEnumerable<StandardQuestion> GetAllQuestions()
    {
        return _standardSurveyQuestions
            .OrderBy(x => x.StandardQuestionOrder)
            .Select(x => x.StandardQuestion);
    }
    public void AssignEmployee(StandardUser user, DateTime dueDate)
    {
        if (_standardSurveyParticipants.Any(x => x.UserId == user.Id))
        {
            return;
        }

        var assignee = new StandardSurveyUser(this, user, dueDate);
        _standardSurveyParticipants.Add(assignee);
    }
    private void UpdateAt()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}
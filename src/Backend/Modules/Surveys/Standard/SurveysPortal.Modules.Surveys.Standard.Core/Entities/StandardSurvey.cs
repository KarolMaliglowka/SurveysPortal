using SurveysPortal.Modules.Users.Core.Entities;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Entities;

public class StandardSurvey
{
    private List<StandardSurveyQuestion> _standardSurveyQuestions = new();
    private List<StandardSurveyUser> _standardSurveyParticipants = new();

    protected StandardSurvey()
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

    public int Id { get; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; private set; }
    public string Introduction { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; }

    public IReadOnlyCollection<StandardSurveyUser> StandardSurveyParticipants =>
        _standardSurveyParticipants.AsReadOnly();

    public IReadOnlyCollection<StandardSurveyQuestion> StandardSurveyQuestions => _standardSurveyQuestions.AsReadOnly();

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name of the survey cannot be empty.", nameof(name));
        }

        Name = name;
        UpdatedAt = DateTime.UtcNow;
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

    public void MarkAsDeleted() => IsDeleted = true;

    public void SetQuestions(IList<StandardQuestionOrder> questions)
    {
        if (questions is null || !questions.Any())
        {
            throw new ArgumentNullException(nameof(questions),
                "Collection of questions must contain at least one question.");
        }

        _standardSurveyQuestions = questions.Select(x => new StandardSurveyQuestion(
                x.Question,
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

    public void AssignEmployee(User employee, DateTime dueDate)
    {
        if (_standardSurveyParticipants.Any(x => x.EmployeeId == employee.Id))
        {
            return;
        }

        var assignee = new StandardSurveyUser(this, employee, dueDate);
        _standardSurveyParticipants.Add(assignee);
    }
}
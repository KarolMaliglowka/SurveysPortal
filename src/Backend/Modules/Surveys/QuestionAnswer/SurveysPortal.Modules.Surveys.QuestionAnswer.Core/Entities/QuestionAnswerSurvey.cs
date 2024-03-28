using SurveysPortal.Modules.Users.Core.Entities;

namespace SurveysPortal.Modules.Surveys.QuestionAnswer.Core.Entities;

public class QuestionAnswerSurvey
{
    private List<QuestionAnswerSurveyQuestion> _questionAnswerSurveyQuestions = new();
    private List<QuestionAnswerSurveyUser> _questionAnswerSurveyParticipants = new();

    protected QuestionAnswerSurvey()
    {
    }

    public QuestionAnswerSurvey
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

    public IReadOnlyCollection<QuestionAnswerSurveyUser> QuestionAnswerSurveyParticipants =>
        _questionAnswerSurveyParticipants.AsReadOnly();

    public IReadOnlyCollection<QuestionAnswerSurveyQuestion> QuestionAnswerSurveyQuestions =>
        _questionAnswerSurveyQuestions.AsReadOnly();


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

    public void SetQuestions(IList<QuestionAnswerQuestionOrder> questions)
    {
        if (questions is null || !questions.Any())
        {
            throw new ArgumentNullException(nameof(questions),
                "Collection of questions must contain at least one question.");
        }

        _questionAnswerSurveyQuestions = questions.Select(x => new QuestionAnswerSurveyQuestion(
                x.Question,
                this,
                x.Index))
            .ToList();

        UpdatedAt = DateTime.UtcNow;
    }

    public IEnumerable<QuestionAnswerQuestion> GetQuestions()
    {
        return _questionAnswerSurveyQuestions
            .OrderBy(x => x.QuestionAnswerQuestionOrder)
            .Select(x => x.QuestionAnswerQuestion);
    }

    public IEnumerable<QuestionAnswerQuestion> GetAllQuestions()
    {
        return _questionAnswerSurveyQuestions
            .OrderBy(x => x.QuestionAnswerQuestionOrder)
            .Select(x => x.QuestionAnswerQuestion);
    }

    public void AssignEmployee(User employee, DateTime dueDate)
    {
        if (_questionAnswerSurveyParticipants.Any(x => x.EmployeeId == employee.Id))
        {
            return;
        }

        var assignee = new QuestionAnswerSurveyUser(this, employee, dueDate);
        _questionAnswerSurveyParticipants.Add(assignee);
    }
}
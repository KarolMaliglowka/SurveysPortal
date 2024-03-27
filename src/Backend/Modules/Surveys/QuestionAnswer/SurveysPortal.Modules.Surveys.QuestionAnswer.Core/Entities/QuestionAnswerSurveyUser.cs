using SurveysPortal.Modules.Users.Core.Entities;

namespace SurveysPortal.Modules.Surveys.QuestionAnswer.Core.Entities;

public class QuestionAnswerSurveyUser
{
    private readonly List<QuestionAnswerAnswer> _answers = new();

    protected QuestionAnswerSurveyUser()
    {
    }

    public QuestionAnswerSurveyUser
    (
        QuestionAnswerSurvey questionAnswerSurvey,
        User employee,
        DateTime dueDate
    )
    {
        QuestionAnswerSurvey = questionAnswerSurvey ?? throw new ArgumentNullException(nameof(questionAnswerSurvey));
        Employee = employee ?? throw new ArgumentNullException(nameof(employee));
        DueDate = dueDate;
    }

    public int Id { get; }
    public int BasicSurveyId { get; set; }
    public QuestionAnswerSurvey QuestionAnswerSurvey { get; set; }
    public Guid EmployeeId { get; set; }
    public User Employee { get; set; }
    public DateTime DueDate { get; set; }
    public int Completion { get; private set; }
}
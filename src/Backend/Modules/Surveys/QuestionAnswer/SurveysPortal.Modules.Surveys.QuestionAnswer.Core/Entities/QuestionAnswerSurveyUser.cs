using SurveysPortal.Modules.Surveys.QuestionAnswer.Core.Services;
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
    public int QuestionAnswerSurveyId { get; set; }
    public QuestionAnswerSurvey QuestionAnswerSurvey { get; set; }
    public Guid EmployeeId { get; set; }
    public User Employee { get; set; }
    public DateTime DueDate { get; set; }
    public int Completion { get; private set; }

    public IReadOnlyCollection<QuestionAnswerAnswer> Answers => _answers.AsReadOnly();

    public IEnumerable<KeyValuePair<QuestionAnswerQuestion, QuestionAnswerAnswer>> GetAllQuestionsWithAnswers()
    {
        return QuestionAnswerSurvey.GetAllQuestions()
            .Select(question =>
            {
                var answer = Answers.FirstOrDefault(y => y.QuestionAnswerQuestion.Id == question.Id);
                return new KeyValuePair<QuestionAnswerQuestion, QuestionAnswerAnswer>(question, answer);
            })
            .ToList();
    }

    public void SetEmployeeAnswers(IEnumerable<KeyValuePair<int, string>> questionIdsWithAnswers, bool canBeClosed)
    {
        foreach (var (questionId, answerText) in questionIdsWithAnswers)
        {
            var question = QuestionAnswerSurvey.GetAllQuestions().FirstOrDefault(x => x.Id == questionId);
            if (question is null)
            {
                continue;
            }

            var answer = GetAnswerForQuestion(questionId);
            if (answer is null)
            {
                answer = new QuestionAnswerAnswer(this, question);
                answer.SetQuestionAnswerAnswer(answerText, canBeClosed);
                _answers.Add(answer);
            }
            else
            {
                answer.SetQuestionAnswerAnswer(answerText, canBeClosed);
            }
        }

        UpdateProgress(canBeClosed);
    }

    private QuestionAnswerAnswer GetAnswerForQuestion(int questionId) =>
        _answers.FirstOrDefault(x => x.QuestionAnswerQuestion.Id == questionId);

    private void UpdateProgress(bool canBeClosed)
    {
        var questions = GetNumberOfQuestions();
        var answers = GetNumberOfAnswers();
        Completion = CompletionCalculator.Calculate(questions, answers, canBeClosed);
    }

    private int GetNumberOfAnswers() =>
        _answers.Count(x => !string.IsNullOrWhiteSpace(x.Answer));

    private int GetNumberOfQuestions() =>
        QuestionAnswerSurvey.QuestionAnswerSurveyQuestions.Count;

    public string GetOverallProgress()
    {
        return Completion switch
        {
            0 => "To do",
            100 => "Done",
            _ => "In progress"
        };
    }

    public void ResetProgress()
    {
        _answers.Clear();
        Completion = 0;
    }
}
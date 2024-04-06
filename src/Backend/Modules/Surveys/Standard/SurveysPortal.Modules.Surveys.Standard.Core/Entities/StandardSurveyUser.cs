using SurveysPortal.Modules.Surveys.Standard.Core.Services;
using SurveysPortal.Modules.Users.Core.Entities;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Entities;

public class StandardSurveyUser
{
    private readonly List<StandardAnswer> _answers = new();

    public StandardSurveyUser()
    {
    }

    public StandardSurveyUser
    (
        StandardSurvey standardSurvey,
        //User employee,
        DateTime dueDate
    )
    {
        StandardSurvey = standardSurvey ?? throw new ArgumentNullException(nameof(standardSurvey));
        //User = employee ?? throw new ArgumentNullException(nameof(employee));
        DueDate = dueDate;
    }

    public int Id { get; }
    public int StandardSurveyId { get; set; }
    public StandardSurvey StandardSurvey { get; set; }
    public Guid UserId { get; set; }
    //public User User { get; set; }
    public DateTime DueDate { get; set; }
    public int Completion { get; private set; }

    public IReadOnlyCollection<StandardAnswer> Answers => _answers.AsReadOnly();
    
    public IEnumerable<KeyValuePair<StandardQuestion, StandardAnswer>> GetAllQuestionsWithAnswers()
    {
        return StandardSurvey.GetAllQuestions()
            .Select(question =>
            {
                var answer = Answers.FirstOrDefault(y => y.StandardQuestion.Id == question.Id);
                return new KeyValuePair<StandardQuestion, StandardAnswer>(question, answer);
            })
            .ToList();
    }

    public void SetEmployeeAnswers(IEnumerable<KeyValuePair<int, string>> questionIdsWithAnswers, bool canBeClosed)
    {
        foreach (var (questionId, answerText) in questionIdsWithAnswers)
        {
            var question = StandardSurvey.GetAllQuestions().FirstOrDefault(x => x.Id == questionId);
            if (question is null)
            {
                continue;
            }

            var answer = GetAnswerForQuestion(questionId);
            if (answer is null)
            {
                answer = new StandardAnswer(this, question);
                answer.SetStandardAnswer(answerText, canBeClosed);
                _answers.Add(answer);
            }
            else
            {
                answer.SetStandardAnswer(answerText, canBeClosed);
            }
        }

        UpdateProgress(canBeClosed);
    }

    private StandardAnswer GetAnswerForQuestion(int questionId) =>
        _answers.FirstOrDefault(x => x.StandardQuestion.Id == questionId);

    private void UpdateProgress(bool canBeClosed)
    {
        var questions = GetNumberOfQuestions();
        var answers = GetNumberOfAnswers();
        Completion = CompletionCalculator.Calculate(questions, answers, canBeClosed);
    }

    private int GetNumberOfAnswers() =>
        _answers.Count(x => !string.IsNullOrWhiteSpace(x.Answer));

    private int GetNumberOfQuestions() =>
        StandardSurvey.StandardSurveyQuestions.Count;

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
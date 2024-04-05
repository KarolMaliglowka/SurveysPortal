using System.Diagnostics.CodeAnalysis;
using SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Entities;

public class StandardAnswer
{
    private const string NotRequired = "Question was not required.";

    [ExcludeFromCodeCoverage]
    public StandardAnswer()
    {
    }

    public StandardAnswer(StandardSurveyUser standardSurveyUser, StandardQuestion standardQuestion)
    {
        StandardSurveyUser = standardSurveyUser ?? throw new ArgumentNullException(nameof(standardSurveyUser),
            "Survey participant cannot be null.");
        StandardQuestion = standardQuestion ?? throw new ArgumentNullException(nameof(standardQuestion),
            "Question cannot be null.");
    }

    public int Id { get; set; }
    public Guid UserId { get; set; }
    public Guid StandardSurveyUserId { get; set; }
    public StandardSurveyUser StandardSurveyUser { get; }
    public StandardQuestion StandardQuestion { get; }
    public string Answer { get; private set; }
    public DateTime AnsweredAt { get; private set; }

    public void SetStandardAnswer(string userAnswer, bool isSubmitted)
    {
        var isList = StandardQuestion.OfferedAnswers.Count != 0;
        var isUserAnswerInOfferedAnswers =
            StandardQuestion.OfferedAnswers.Any(x => x.Trim() == userAnswer?.Trim());
        var isRequired = StandardQuestion.Required;
        switch (isSubmitted)
        {
            case true when !isUserAnswerInOfferedAnswers && isList && isRequired:
                throw new NotFoundOfferedAnswerException(
                    "Not found this answer in list of offered answers for user.");
            case true when string.IsNullOrWhiteSpace(userAnswer):
            {
                if (StandardQuestion.Required)
                {
                    throw new ArgumentException("Answer for this question is required.", nameof(userAnswer));
                }

                userAnswer = NotRequired;
                break;
            }
        }
        Answer = userAnswer;
        AnsweredAt = DateTime.UtcNow;
    }
}
using System.Diagnostics.CodeAnalysis;
using SurveysPortal.Modules.Surveys.QuestionAnswer.Core.Exceptions;

namespace SurveysPortal.Modules.Surveys.QuestionAnswer.Core.Entities;

public class QuestionAnswerAnswer
{
    private const string NotRequired = "Question was not required.";

    [ExcludeFromCodeCoverage]
    protected QuestionAnswerAnswer()
    {
    }

    public QuestionAnswerAnswer(QuestionAnswerSurveyUser questionAnswerSurveyUser,
        QuestionAnswerQuestion questionAnswerQuestion)
    {
        QuestionAnswerSurveyUser = questionAnswerSurveyUser ??
                                   throw new ArgumentNullException(nameof(questionAnswerSurveyUser),
                                       "Survey participant cannot be null.");
        QuestionAnswerQuestion = questionAnswerQuestion ??
                                 throw new ArgumentNullException(nameof(questionAnswerQuestion),
                                     "Question cannot be null.");
    }

    [ExcludeFromCodeCoverage] public int Id { get; }
    public Guid UserId { get; set; }
    public int AnswerQuestionSurveyUserId { get; set; }
    public QuestionAnswerSurveyUser QuestionAnswerSurveyUser { get; }
    public QuestionAnswerQuestion QuestionAnswerQuestion { get; }
    public string Answer { get; private set; }
    public DateTime AnsweredAt { get; private set; }

    public void SetQuestionAnswerAnswer(string userAnswer, bool isSubmitted)
    {
        var isList = QuestionAnswerQuestion.OfferedAnswers.Count != 0;
        var isUserAnswerInOfferedAnswers =
            QuestionAnswerQuestion.OfferedAnswers.Any(x => x.Trim() == userAnswer?.Trim());
        var isRequired = QuestionAnswerQuestion.Required;

        switch (isSubmitted)
        {
            case true when !isUserAnswerInOfferedAnswers && isList && isRequired:
                throw new NotFoundOfferedAnswerException(
                    "Not found this answer in list of offered answers for user.");
            case true when string.IsNullOrWhiteSpace(userAnswer):
            {
                if (QuestionAnswerQuestion.Required)
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
using System.Diagnostics.CodeAnalysis;

namespace SurveysPortal.Modules.Surveys.QuestionAnswer.Core.Entities;

public class QuestionAnswerSurveyQuestion
{
    [ExcludeFromCodeCoverage]
    protected QuestionAnswerSurveyQuestion()
    {
    }

    public QuestionAnswerSurveyQuestion(QuestionAnswerQuestion questionAnswerQuestion,
        QuestionAnswerSurvey questionAnswerSurvey)
    {
        SetQuestion(questionAnswerQuestion);
        SetSurvey(questionAnswerSurvey);
    }

    public QuestionAnswerSurveyQuestion(QuestionAnswerQuestion questionAnswerQuestion,
        QuestionAnswerSurvey questionAnswerSurvey, int index)
    {
        SetQuestion(questionAnswerQuestion);
        SetSurvey(questionAnswerSurvey);
        SetOrder(index);
    }

    [ExcludeFromCodeCoverage] public int QuestionAnswerQuestionId { get; }
    public QuestionAnswerQuestion QuestionAnswerQuestion { get; private set; }
    [ExcludeFromCodeCoverage] public int QuestionAnswerSurveyId { get; }
    public QuestionAnswerSurvey QuestionAnswerSurvey { get; private set; }
    public int QuestionAnswerQuestionOrder { get; private set; }

    [ExcludeFromCodeCoverage]
    private void SetQuestion(QuestionAnswerQuestion questionAnswerQuestion)
    {
        QuestionAnswerQuestion = questionAnswerQuestion ??
                                 throw new ArgumentNullException(nameof(questionAnswerQuestion),
                                     "Question cannot be null.");
    }

    [ExcludeFromCodeCoverage]
    private void SetSurvey(QuestionAnswerSurvey questionAnswerSurvey)
    {
        QuestionAnswerSurvey = questionAnswerSurvey ??
                               throw new ArgumentNullException(nameof(questionAnswerSurvey), "Survey cannot be null.");
    }

    public void SetOrder(int index)
    {
        if (index < 0)
        {
            throw new ArgumentException("Order index cannot be lower than 0.", nameof(index));
        }

        QuestionAnswerQuestionOrder = index;
    }
}
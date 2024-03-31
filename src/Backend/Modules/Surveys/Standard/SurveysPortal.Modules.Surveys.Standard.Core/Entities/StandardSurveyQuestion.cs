using System.Diagnostics.CodeAnalysis;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Entities;

public class StandardSurveyQuestion
{
    [ExcludeFromCodeCoverage]
    public StandardSurveyQuestion()
    {
    }

    public StandardSurveyQuestion(StandardQuestion standardQuestion, StandardSurvey standardSurvey)
    {
        SetQuestion(standardQuestion);
        SetSurvey(standardSurvey);
    }

    public StandardSurveyQuestion(StandardQuestion standardQuestion, StandardSurvey standardSurvey, int index)
    {
        SetQuestion(standardQuestion);
        SetSurvey(standardSurvey);
        SetOrder(index);
    }

    [ExcludeFromCodeCoverage] public int StandardQuestionId { get; }
    public StandardQuestion StandardQuestion { get; private set; }
    [ExcludeFromCodeCoverage] public int StandardSurveyId { get; }
    public StandardSurvey StandardSurvey { get; private set; }
    public int StandardQuestionOrder { get; private set; }

    [ExcludeFromCodeCoverage]
    private void SetQuestion(StandardQuestion standardQuestion)
    {
        StandardQuestion = standardQuestion ?? throw new ArgumentNullException(nameof(standardQuestion),
            "Question cannot be null.");
    }

    [ExcludeFromCodeCoverage]
    private void SetSurvey(StandardSurvey standardSurvey)
    {
        StandardSurvey = standardSurvey ?? throw new ArgumentNullException(nameof(standardSurvey),
            "Survey cannot be null.");
    }

    public void SetOrder(int index)
    {
        if (index < 0)
        {
            throw new ArgumentException("Order index cannot be lower than 0.", nameof(index));
        }

        StandardQuestionOrder = index;
    }
}
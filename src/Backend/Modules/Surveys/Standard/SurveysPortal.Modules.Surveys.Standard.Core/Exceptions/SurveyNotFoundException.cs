using SurveysPortal.Shared.Infrastructure.Exceptions;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;

public class SurveyNotFoundException : CustomException
{
    public int SurveyId { get; }

    public SurveyNotFoundException() : base(null!) {}
    
    public SurveyNotFoundException(int surveyId) : base($"Survey with ID: '{surveyId}' was not found.")
    {
        SurveyId = surveyId;
    }
}
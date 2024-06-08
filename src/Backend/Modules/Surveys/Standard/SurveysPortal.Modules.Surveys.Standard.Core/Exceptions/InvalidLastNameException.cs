using SurveysPortal.Modules.Surveys.Standard.Core.ValueObjects;
using SurveysPortal.Shared.Infrastructure.Exceptions;

namespace SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;

public class InvalidLastNameException : CustomException
{
    public InvalidLastNameException() : base(null!)
    {
    }

    public InvalidLastNameException(SurveyName surveyName) : base($"Last name: '{surveyName}' is invalid.")
    {
        SurveyName = surveyName;
    }

    public SurveyName SurveyName { get; }
}
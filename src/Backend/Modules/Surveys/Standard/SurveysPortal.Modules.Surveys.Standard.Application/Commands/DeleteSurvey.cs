using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Commands;

public class DeleteSurvey : ICommand
{
    public int SurveyId { get; set; }
}
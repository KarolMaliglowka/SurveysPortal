using SurveysPortal.Modules.Surveys.Standard.Application.DTO;
using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Commands;

public class EditSurvey : ICommand
{
    public int SurveyId { get; set; }
    public NewSurvey? Survey { get; set; }
}
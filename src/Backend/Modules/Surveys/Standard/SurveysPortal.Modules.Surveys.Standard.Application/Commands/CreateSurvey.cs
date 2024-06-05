
using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Commands;

public class CreateSurvey : ICommand
{
    public string? Survey { get; set; }
    public string? Description { get; set; }
    public string? Introduction { get; set; }
}
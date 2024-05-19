using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Commands;

public record CreateQuestion : ICommand
{
    public string? Question { get; set; }
    public bool Require { get; set; }
}
using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Commands;

public class DeleteQuestion : ICommand
{
    public int QuestionId { get; set; }
}
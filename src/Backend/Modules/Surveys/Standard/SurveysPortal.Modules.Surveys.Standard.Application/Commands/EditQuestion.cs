using SurveysPortal.Modules.Surveys.Standard.Application.DTO;
using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Commands;

public class EditQuestion : ICommand
{
    public int QuestionId { get; set; }
    public QuestionDto? Question { get; set; }
}
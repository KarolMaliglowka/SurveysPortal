using SurveysPortal.Modules.Surveys.Standard.Core.Entities;
using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Commands;

public class EditQuestion : ICommand
{
    public StandardQuestion? Question { get; set; }
}
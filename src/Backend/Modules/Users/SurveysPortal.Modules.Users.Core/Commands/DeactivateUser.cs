using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Users.Core.Commands;

public class DeactivateUser : ICommand
{
    public Guid UserId { get; set; }
}
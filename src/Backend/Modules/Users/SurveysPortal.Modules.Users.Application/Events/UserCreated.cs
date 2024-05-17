using SurveysPortal.Shared.Abstractions.Events;

namespace SurveysPortal.Modules.Users.Application.Events;

public record UserCreated : IEvent
{
    public Guid UserId { get; set; }
    public string? Email { get; set; }
    public string? FullName { get; set; }
}
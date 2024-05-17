using SurveysPortal.Modules.Notifications.Api.Services;
using SurveysPortal.Modules.Users.Application.Events;
using SurveysPortal.Shared.Abstractions.Events;

namespace SurveysPortal.Modules.Notifications.Api.Handlers;

public class UserCreatedHandler : IEventHandler<UserCreated>
{
    private readonly IEmailSender _emailSender = null!;

    public UserCreatedHandler() { }

    public UserCreatedHandler(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public Task HandleAsync(UserCreated @event, CancellationToken cancellationToken = default) => 
        _emailSender.SendAsync(@event.Email!, "NewUser");
}
using SurveysPortal.Modules.Notifications.Application;

namespace SurveysPortal.Modules.Notifications.Api.Services;

public class NotificationsModuleApi : INotificationsModuleApi
{
    private readonly IEmailSender _emailSender;
    
    public NotificationsModuleApi(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }
    
    public Task SendEmailAsync(string receiver, string template)
        => _emailSender.SendAsync(receiver, template);
}
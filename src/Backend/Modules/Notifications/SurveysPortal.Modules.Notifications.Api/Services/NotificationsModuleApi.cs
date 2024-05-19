using SurveysPortal.Modules.Notifications.Application;

namespace SurveysPortal.Modules.Notifications.Api.Services;

public class NotificationsModuleApi(IEmailSender emailSender) : INotificationsModuleApi
{
    public Task SendEmailAsync(string receiver, string template)
        => emailSender.SendAsync(receiver, template);
}
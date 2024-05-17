namespace SurveysPortal.Modules.Notifications.Api.Services;

public interface IEmailSender
{
    Task SendAsync(string receiver, string template);
}
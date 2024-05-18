namespace SurveysPortal.Modules.Notifications.Application;

public interface INotificationsModuleApi
{
    Task SendEmailAsync(string receiver, string template);
}
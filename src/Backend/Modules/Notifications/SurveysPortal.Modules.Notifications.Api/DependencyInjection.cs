using SurveysPortal.Modules.Notifications.Application;
using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Notifications.Api.Services;

namespace SurveysPortal.Modules.Notifications.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddNotificationsModule(this IServiceCollection services)
    {
        services.AddTransient<INotificationsModuleApi, NotificationsModuleApi>();
        services.AddSingleton<IEmailSender, EmailSender>();

        services.AddNotificationsApplicationLayer();

        return services;
    }
}
using SurveysPortal.Modules.Notifications.Application;
using Microsoft.Extensions.DependencyInjection;

namespace SurveysPortal.Modules.Notifications.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddNotificationsModule(this IServiceCollection services)
    {
        services
            .AddNotificationsApplicationLayer();

        return services;
    }
}
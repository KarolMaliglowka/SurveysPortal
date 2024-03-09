using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Notifications.Application;

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
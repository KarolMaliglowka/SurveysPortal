using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Shared.Infrastructure;

namespace SurveysPortal.Modules.Notifications.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddNotificationsApplicationLayer(this IServiceCollection services)
    {
        services.Scan(s => s
            .FromCallingAssembly()
            .AddClasses()
            .InjectableAttributes());

        return services;
    }
}
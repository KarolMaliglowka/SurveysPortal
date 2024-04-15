using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Shared.Infrastructure;

namespace SurveysPortal.Modules.Users.Application;

public static class ServicesRegistration
{
    public static IServiceCollection AddUsersApplicationLayer(this IServiceCollection services)
    {
        services.Scan(s => s
            .FromCallingAssembly()
            .AddClasses()
            .InjectableAttributes());

        return services;
    }
}
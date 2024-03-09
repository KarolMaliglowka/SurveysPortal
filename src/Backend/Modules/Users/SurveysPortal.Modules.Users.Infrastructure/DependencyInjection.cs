using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Shared.Infrastructure;

namespace SurveysPortal.Modules.Users.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddUsersInfrastructureLayer(this IServiceCollection services)
    {
        services.Scan(s => s
            .FromCallingAssembly()
            .AddClasses()
            .InjectableAttributes());
        
        return services;
    }
}
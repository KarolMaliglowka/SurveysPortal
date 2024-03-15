using Microsoft.Extensions.DependencyInjection;

namespace SurveysPortal.Shared.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
    {
        services.Scan(s => s
            .FromCallingAssembly()
            .AddClasses()
            .InjectableAttributes());

        return services;
    }
}
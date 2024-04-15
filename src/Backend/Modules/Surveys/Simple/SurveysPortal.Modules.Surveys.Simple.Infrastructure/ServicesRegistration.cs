using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Shared.Infrastructure;

namespace SurveysPortal.Modules.Surveys.Simple.Infrastructure;

public static class ServicesRegistration
{
    public static IServiceCollection AddSurveysSimpleInfrastructureLayer(this IServiceCollection services)
    {
        services.Scan(s => s
            .FromCallingAssembly()
            .AddClasses()
            .InjectableAttributes());
        
        return services;
    }
}
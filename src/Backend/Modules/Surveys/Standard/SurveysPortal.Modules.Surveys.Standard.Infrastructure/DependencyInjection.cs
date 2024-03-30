using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Shared.Infrastructure;

namespace SurveysPortal.Modules.Surveys.Standard.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddSurveysStandardInfrastructureLayer(this IServiceCollection services)
    {
        services.Scan(s => s
            .FromCallingAssembly()
            .AddClasses()
            .InjectableAttributes());

        return services;
    }
}
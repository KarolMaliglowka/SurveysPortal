using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Shared.Infrastructure;

namespace SurveysPortal.Modules.Surveys.Standard.Application;

public static class ServicesRegistration
{
    public static IServiceCollection AddSurveysStandardApplicationLayer(this IServiceCollection services)
    {
        services.Scan(s => s
            .FromCallingAssembly()
            .AddClasses()
            .InjectableAttributes());

        return services;
    }
}
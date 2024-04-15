using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Surveys.Simple.Core;
using SurveysPortal.Modules.Surveys.Simple.Infrastructure;

namespace SurveysPortal.Modules.Surveys.Simple.Api;

public static class ServicesRegistration
{
    public static IServiceCollection AddSurveysSimpleModule(this IServiceCollection services)
    {
        services
            .AddSurveysSimpleCoreLayer()
            .AddSurveysSimpleInfrastructureLayer();

        return services;
    }
}
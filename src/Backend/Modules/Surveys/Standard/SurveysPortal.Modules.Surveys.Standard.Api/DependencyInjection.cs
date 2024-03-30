using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Surveys.Standard.Core;
using SurveysPortal.Modules.Surveys.Standard.Infrastructure;

namespace SurveysPortal.Modules.Surveys.Standard.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddSurveysStandardApiModule(this IServiceCollection services)
    {
        services
            .AddSurveysStandardCoreLayer()
            .AddSurveysStandardInfrastructureLayer();

        return services;
    }
}
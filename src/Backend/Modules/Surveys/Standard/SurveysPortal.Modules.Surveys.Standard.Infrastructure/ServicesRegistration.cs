using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Surveys.Standard.Infrastructure.DAL;
using SurveysPortal.Shared.Infrastructure;
using SurveysPortal.Shared.Infrastructure.Database;

namespace SurveysPortal.Modules.Surveys.Standard.Infrastructure;

public static class ServicesRegistration
{
    public static IServiceCollection AddSurveysStandardInfrastructureLayer(this IServiceCollection services)
    {
        services.AddPostgres<StandardSurveysDbContext>();
        services.Scan(s => s
            .FromCallingAssembly()
            .AddClasses()
            .InjectableAttributes());

        return services;
    }
}
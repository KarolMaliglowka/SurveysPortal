using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

    public static async Task SeedStandardQuestionsData(this IHost app)
    {
        var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

        using var scope = scopedFactory?.CreateScope();
        var service = scope?.ServiceProvider.GetService<DefaultQuestions>();
        if (service is null)
        {
            throw new InvalidOperationException
                ("Could not seed data due to issue with resolving service DefaultStandardQuestions");
        }

        await service.SeedStandardQuestions();
    }
    
    public static async Task SeedStandardSurveysData(this IHost app)
    {
        var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

        using var scope = scopedFactory?.CreateScope();
        var service = scope?.ServiceProvider.GetService<DefaultSurveys>();
        if (service is null)
        {
            throw new InvalidOperationException
                ("Could not seed data due to issue with resolving service DefaultStandardSurveys");
        }

        await service.SeedStandardSurveys();
    }
}
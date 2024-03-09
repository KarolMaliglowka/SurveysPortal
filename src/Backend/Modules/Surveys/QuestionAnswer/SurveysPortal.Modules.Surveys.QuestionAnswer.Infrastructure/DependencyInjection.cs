using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Shared.Infrastructure;

namespace SurveysPortal.Modules.Surveys.QuestionAnswer.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddSurveysQuestionAnswerInfrastructureLayer(this IServiceCollection services)
    {
        services.Scan(s => s
            .FromCallingAssembly()
            .AddClasses()
            .InjectableAttributes());
        
        return services;
    }
}
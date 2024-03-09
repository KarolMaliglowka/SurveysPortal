using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Shared.Infrastructure;

namespace SurveysPortal.Modules.Surveys.QuestionAnswer.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddSurveysQuestionAnswerCoreLayer(this IServiceCollection services)
    {
        services.Scan(s => s
            .FromCallingAssembly()
            .AddClasses()
            .InjectableAttributes());
        
        return services;
    }
}
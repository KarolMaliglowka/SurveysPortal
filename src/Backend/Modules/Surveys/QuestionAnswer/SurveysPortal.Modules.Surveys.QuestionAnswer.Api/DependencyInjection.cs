using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Surveys.QuestionAnswer.Core;
using SurveysPortal.Modules.Surveys.QuestionAnswer.Infrastructure;

namespace SurveysPortal.Modules.Surveys.QuestionAnswer.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddSurveysQuestionAnswerModule(this IServiceCollection services)
    {
        services
            .AddSurveysQuestionAnswerCoreLayer()
            .AddSurveysQuestionAnswerInfrastructureLayer();

        return services;
    }
}
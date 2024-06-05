using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Surveys.Standard.Core.Entities;
using SurveysPortal.Modules.Surveys.Standard.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;
using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Commands.Handlers;

[Injectable(ServiceLifetime.Scoped)]
public class CreateSurveyHandler : ICommandHandler<CreateSurvey>
{
    private readonly ISurveyRepository _surveyRepository;

    public CreateSurveyHandler()
    {
    }

    public CreateSurveyHandler(ISurveyRepository surveyRepository)
    {
        _surveyRepository = surveyRepository;
    }

    public async Task HandleAsync(CreateSurvey command, CancellationToken cancellationToken = default)
    {
        var survey = new StandardSurvey(
            command.Survey!,
            command.Description!,
            command.Introduction!
        );
        await _surveyRepository.Create(survey);
    }
}
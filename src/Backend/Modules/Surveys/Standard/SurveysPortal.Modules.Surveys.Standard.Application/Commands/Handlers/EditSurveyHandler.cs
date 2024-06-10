using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;
using SurveysPortal.Modules.Surveys.Standard.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;
using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Commands.Handlers;

[Injectable(ServiceLifetime.Scoped)]
public class EditSurveyHandler : ICommandHandler<EditSurvey>
{
    private readonly ISurveyRepository _surveyRepository;

    public EditSurveyHandler()
    {
    }

    public EditSurveyHandler(ISurveyRepository surveyRepository)
    {
        _surveyRepository = surveyRepository;
    }

    public async Task HandleAsync(EditSurvey command, CancellationToken cancellationToken = default)
    {
        if (command.Survey != null)
        {
            var survey = await _surveyRepository
                .GetStandardSurveyById(command.SurveyId);
            if (survey is null)
            {
                throw new SurveyNotFoundException(command.SurveyId);
            }
            survey.SetName(command.Survey.Survey!);
            survey.SetDescription(command.Survey.Description!);
            survey.SetIntroduction(command.Survey.Introduction!);
            await _surveyRepository.Update(survey);
        }
    }
}
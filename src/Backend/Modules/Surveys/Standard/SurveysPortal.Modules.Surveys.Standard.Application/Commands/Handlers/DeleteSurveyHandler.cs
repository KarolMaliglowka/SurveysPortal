using SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;
using SurveysPortal.Modules.Surveys.Standard.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Commands.Handlers;

public class DeleteSurveyHandler : ICommandHandler<DeleteSurvey>
{
    private readonly ISurveyRepository _surveyRepository;

    public DeleteSurveyHandler()
    {
    }

    public DeleteSurveyHandler(ISurveyRepository surveyRepository)
    {
        _surveyRepository = surveyRepository;
    }
    
    public async Task HandleAsync(DeleteSurvey command, CancellationToken cancellationToken = default)
    {
        var survey = await _surveyRepository
            .GetStandardSurveyById(command.SurveyId);
        if (survey is null)
        {
            throw new SurveyNotFoundException(command.SurveyId);
        }

        survey.SetAsDeleted();
        await _surveyRepository.Update(survey);
    }
}
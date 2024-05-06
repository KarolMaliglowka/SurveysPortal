using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Surveys.Standard.Application.DTO;
using SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;
using SurveysPortal.Modules.Surveys.Standard.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;
using SurveysPortal.Shared.Abstractions.Queries;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Queries.Handlers;

[Injectable(ServiceLifetime.Scoped)]
public class GetSurveyHandler : IQueryHandler<GetSurvey, SurveyDto>
{
    private readonly ISurveyRepository _surveyRepository;

    public GetSurveyHandler()
    {
    }

    public GetSurveyHandler(ISurveyRepository surveyRepository)
    {
        _surveyRepository = surveyRepository;
    }

    public async Task<SurveyDto> HandleAsync(GetSurvey query, CancellationToken cancellationToken = default)
    {
        var survey = await _surveyRepository.GetStandardSurveyById(query.SurveyId);
        if (survey is null)
        {
            throw new SurveyNotFoundException(query.SurveyId);
        }

        return new SurveyDto
        {
            SurveyId = survey.Id,
            Name = survey.Name,
            Description = survey.Description
        } ?? throw new InvalidOperationException();
    }
}
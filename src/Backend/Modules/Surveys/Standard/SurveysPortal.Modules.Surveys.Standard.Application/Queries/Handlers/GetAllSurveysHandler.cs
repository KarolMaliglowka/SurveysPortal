using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Surveys.Standard.Application.DTO;
using SurveysPortal.Modules.Surveys.Standard.Application.DTO.Extensions;
using SurveysPortal.Modules.Surveys.Standard.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;
using SurveysPortal.Shared.Abstractions.Queries;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Queries.Handlers;

[Injectable(ServiceLifetime.Scoped)]
public class GetAllSurveysHandler : IQueryHandler<GetAllSurveys, IEnumerable<SurveyDto>>
{
    private readonly ISurveyRepository _surveyRepository;
    
    public GetAllSurveysHandler() {}
    
    public GetAllSurveysHandler(ISurveyRepository surveyRepository)
    {
        _surveyRepository = surveyRepository;
    }

    public async Task<IEnumerable<SurveyDto>> HandleAsync(GetAllSurveys query,
        CancellationToken cancellationToken = default)
    {
        var questionList = await _surveyRepository
            .GetAllStandardSurveys();
        return questionList.ToStandardSurveysListDto();
    }
}
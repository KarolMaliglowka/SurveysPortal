using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Surveys.Standard.Application.DTO;
using SurveysPortal.Modules.Surveys.Standard.Application.DTO.Extensions;
using SurveysPortal.Modules.Surveys.Standard.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;
using SurveysPortal.Shared.Abstractions.Queries;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Queries.Handlers;

[Injectable(ServiceLifetime.Scoped)]
public class GetAllQuestionsHandler : IQueryHandler<GetAllQuestions, IEnumerable<QuestionDto>>
{
    private readonly IQuestionRepository _questionRepository;
    
    public GetAllQuestionsHandler() {}
    
    public GetAllQuestionsHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<IEnumerable<QuestionDto>> HandleAsync(GetAllQuestions query,
        CancellationToken cancellationToken = default)
    {
        var questionList = await _questionRepository
            .GetAllStandardQuestions();
        return questionList
            .ToStandardQuestionsListDto();
    }
}
using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Surveys.Standard.Application.DTO;
using SurveysPortal.Modules.Surveys.Standard.Application.DTO.Extensions;
using SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;
using SurveysPortal.Modules.Surveys.Standard.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;
using SurveysPortal.Shared.Abstractions.Queries;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Queries.Handlers;

[Injectable(ServiceLifetime.Scoped)]
public class GetQuestionHandler : IQueryHandler<GetQuestion, QuestionDto>
{
    private readonly IQuestionRepository _questionRepository;

    public GetQuestionHandler() {}

    public GetQuestionHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<QuestionDto> HandleAsync(GetQuestion query, CancellationToken cancellationToken = default)
    {
        var question = await _questionRepository.GetStandardQuestionById(query.QuestionId);
        if (question is null)
        {
            throw new QuestionNotFoundException(query.QuestionId);
        }

        return question.ToStandardQuestionDto() ?? throw new InvalidOperationException();
    }
}
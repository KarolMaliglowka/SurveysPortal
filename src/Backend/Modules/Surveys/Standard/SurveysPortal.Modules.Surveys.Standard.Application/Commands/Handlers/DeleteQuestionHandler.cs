using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;
using SurveysPortal.Modules.Surveys.Standard.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;
using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Commands.Handlers;

[Injectable(ServiceLifetime.Scoped)]
public class DeleteQuestionHandler : ICommandHandler<DeleteQuestion>
{
    private readonly IQuestionRepository _questionRepository;

    public DeleteQuestionHandler() {}

    public DeleteQuestionHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task HandleAsync(DeleteQuestion command, CancellationToken cancellationToken = default)
    {
        var question = await _questionRepository.GetStandardQuestionById(command.QuestionId);
        if (question is null)
        {
            throw new QuestionNotFoundException(command.QuestionId);
        }

        question.SetAsDeleted();
        await _questionRepository.Update(question);
    }
}
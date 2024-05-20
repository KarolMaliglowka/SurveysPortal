using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Surveys.Standard.Core.Exceptions;
using SurveysPortal.Modules.Surveys.Standard.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;
using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Commands.Handlers;

[Injectable(ServiceLifetime.Scoped)]
public class EditQuestionHandler : ICommandHandler<EditQuestion>
{
    private readonly IQuestionRepository _questionRepository;

    public EditQuestionHandler() {}

    public EditQuestionHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task HandleAsync(EditQuestion command, CancellationToken cancellationToken = default)
    {
        if (command.Question != null)
        {
            var question = await _questionRepository
                .GetStandardQuestionById(command!.QuestionId);
            if (question is null)
            {
                throw new QuestionNotFoundException(command.QuestionId);
            }

            question.SetQuestion(command.Question.Question!);
            question.Required = command.Question.Required;
            
            await _questionRepository.Update(question);
        }
    }
}
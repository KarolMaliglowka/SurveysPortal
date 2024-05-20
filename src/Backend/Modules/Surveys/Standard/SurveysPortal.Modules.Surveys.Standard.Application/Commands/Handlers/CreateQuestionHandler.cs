using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Surveys.Standard.Core.Entities;
using SurveysPortal.Modules.Surveys.Standard.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;
using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Commands.Handlers;

[Injectable(ServiceLifetime.Scoped)]
public class CreateQuestionHandler : ICommandHandler<CreateQuestion>
{
    private readonly IQuestionRepository _questionRepository;

    public CreateQuestionHandler() {}

    public CreateQuestionHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task HandleAsync(CreateQuestion command, CancellationToken cancellationToken = default)
    {
        var question = new StandardQuestion(command.Question!, command.Require);
        await _questionRepository.Create(question);
    }
}
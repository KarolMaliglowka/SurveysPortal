using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Modules.Surveys.Standard.Core.Repositories;
using SurveysPortal.Shared.Abstractions.Attributes;
using SurveysPortal.Shared.Abstractions.Commands;

namespace SurveysPortal.Modules.Surveys.Standard.Application.Commands.Handlers;

[Injectable(ServiceLifetime.Scoped)]
public class EditQuestionHandler : ICommandHandler<EditQuestion>
{
    private readonly IQuestionRepository _questionRepository;

    public EditQuestionHandler()
    {
    }

    public EditQuestionHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task HandleAsync(EditQuestion command, CancellationToken cancellationToken = default)
    {
        
    }

}
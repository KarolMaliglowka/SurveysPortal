using System;
using System.Threading;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SurveysPortal.Shared.Abstractions.Commands;


namespace SurveysPortal.Shared.Infrastructure.Database.Decorators;


[Decorator]
public class TransactionalCommandHandlerDecorator<T> : ICommandHandler<T> where T : class, ICommand
{
    private readonly ICommandHandler<T> _handler;
    private readonly UnitOfWorkTypeRegistry _unitOfWorkTypeRegistry;
    private readonly IServiceProvider _serviceProvider;

    public TransactionalCommandHandlerDecorator(ICommandHandler<T> handler, UnitOfWorkTypeRegistry unitOfWorkTypeRegistry,
        IServiceProvider serviceProvider)
    {
        _handler = handler;
        _unitOfWorkTypeRegistry = unitOfWorkTypeRegistry;
        _serviceProvider = serviceProvider;
    }

    public async Task HandleAsync(T command, CancellationToken cancellationToken = default)
    {
        var unitOfWorkType = _unitOfWorkTypeRegistry.Resolve<T>();
        if (unitOfWorkType is null)
        {
            await _handler.HandleAsync(command, cancellationToken);
            return;
        }

        var unitOfWork = (IUnitOfWork) _serviceProvider.GetRequiredService(unitOfWorkType);
        var unitOfWorkName = unitOfWorkType.Name;
        var name = command.GetType().Name.Underscore();
        await unitOfWork.ExecuteAsync(() => _handler.HandleAsync(command, cancellationToken));
    }
}
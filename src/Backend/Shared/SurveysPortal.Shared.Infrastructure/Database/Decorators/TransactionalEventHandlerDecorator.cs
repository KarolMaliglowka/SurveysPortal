using System;
using System.Threading;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Shared.Abstractions.Events;

namespace SurveysPortal.Shared.Infrastructure.Database.Decorators;

[Decorator]
public class TransactionalEventHandlerDecorator<T> : IEventHandler<T> where T : class, IEvent
{
    private readonly IEventHandler<T> _handler;
    private readonly UnitOfWorkTypeRegistry _unitOfWorkTypeTypeRegistry;
    private readonly IServiceProvider _serviceProvider;

    public TransactionalEventHandlerDecorator(IEventHandler<T> handler, UnitOfWorkTypeRegistry unitOfWorkTypeTypeRegistry,
        IServiceProvider serviceProvider)
    {
        _handler = handler;
        _unitOfWorkTypeTypeRegistry = unitOfWorkTypeTypeRegistry;
        _serviceProvider = serviceProvider;
    }

    public async Task HandleAsync(T @event, CancellationToken cancellationToken = default)
    {
        var unitOfWorkType = _unitOfWorkTypeTypeRegistry.Resolve<T>();
        if (unitOfWorkType is null)
        {
            await _handler.HandleAsync(@event, cancellationToken);
            return;
        }

        var unitOfWork = (IUnitOfWork) _serviceProvider.GetRequiredService(unitOfWorkType);
        var unitOfWorkName = unitOfWorkType.Name;
        var name = @event.GetType().Name.Underscore();
        await unitOfWork.ExecuteAsync(() => _handler.HandleAsync(@event, cancellationToken));
    }
}
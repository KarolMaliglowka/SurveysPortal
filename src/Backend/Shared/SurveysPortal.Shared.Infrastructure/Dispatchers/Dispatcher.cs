using Microsoft.Extensions.DependencyInjection;
using SurveysPortal.Shared.Abstractions.Attributes;
using SurveysPortal.Shared.Abstractions.Commands;
using SurveysPortal.Shared.Abstractions.Dispatchers;
using SurveysPortal.Shared.Abstractions.Events;
using SurveysPortal.Shared.Abstractions.Queries;

namespace SurveysPortal.Shared.Infrastructure.Dispatchers;

[Injectable(ServiceLifetime.Scoped)]
internal sealed class Dispatcher(
    ICommandDispatcher commandDispatcher,
    IEventDispatcher eventDispatcher,
    IQueryDispatcher queryDispatcher)
    : IDispatcher
{
    public Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand
        => commandDispatcher.SendAsync(command, cancellationToken);

    public Task<TResult> SendAsyncWithResponse<TResult>(ICommand<TResult> command,
        CancellationToken cancellationToken = default)
        => commandDispatcher.SendAsyncWithResponse(command, cancellationToken);

    public Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : class, IEvent
        => eventDispatcher.PublishAsync(@event, cancellationToken);

    public Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
        => queryDispatcher.QueryAsync(query, cancellationToken);
}
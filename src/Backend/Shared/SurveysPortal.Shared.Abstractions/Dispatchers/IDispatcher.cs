using SurveysPortal.Shared.Abstractions.Commands;
using SurveysPortal.Shared.Abstractions.Events;
using SurveysPortal.Shared.Abstractions.Queries;

namespace SurveysPortal.Shared.Abstractions.Dispatchers;

public interface IDispatcher
{
    Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand;
    Task<TResult> SendAsyncWithResponse<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);
    Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : class, IEvent;
    Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}
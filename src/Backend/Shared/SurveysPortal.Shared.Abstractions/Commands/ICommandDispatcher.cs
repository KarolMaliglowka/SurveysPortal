namespace SurveysPortal.Shared.Abstractions.Commands;

public interface ICommandDispatcher
{
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : class, ICommand;
    Task<TResult> SendAsyncWithResponse<TResult>(ICommand<TResult> command, CancellationToken cancellationToken = default);
}
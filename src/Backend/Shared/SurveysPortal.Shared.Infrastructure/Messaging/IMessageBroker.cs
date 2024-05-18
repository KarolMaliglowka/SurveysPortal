using SurveysPortal.Shared.Abstractions.Events;

namespace SurveysPortal.Shared.Infrastructure.Messaging;

public interface IMessageBroker
{
    Task PublishAsync(IEvent @event, CancellationToken cancellationToken = default);
}
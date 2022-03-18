using System.Threading;
using System.Threading.Tasks;
using DDD.Domain.Events;
using MediatR;

namespace DDD.Domain.EventHandlers
{
    public class ProductEventHandler : INotificationHandler<ProductAddedEvent>,
        INotificationHandler<ProductUpdatedEvent>,
        INotificationHandler<ProductRemovedEvent>
    {
        public Task Handle(ProductAddedEvent notification, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }

        public Task Handle(ProductUpdatedEvent notification, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }

        public Task Handle(ProductRemovedEvent notification, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }
    }
}

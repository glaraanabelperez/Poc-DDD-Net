using Aplication.Interfaces;
using Domain.Events;
using Infraestructure.IntegrationCommand;
using MediatR;

namespace Infra.Events.Handlers
{
    public class ProductCreatedIntegrationEventHandler
    : INotificationHandler<ProductCreatedNotificationEvent>
    {
        private readonly IRabbitPublisher _publisher;

        public ProductCreatedIntegrationEventHandler(IRabbitPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task Handle(ProductCreatedNotificationEvent notification, CancellationToken cancellationToken)
        {
            var evt = new ProductCreatedIntegrationEvent(
            notification.name,
            notification.stock,
            notification.desposito,
            notification.id
            );

            await _publisher.Publish(evt);
        }
    }
}

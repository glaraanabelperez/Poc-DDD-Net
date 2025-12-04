using Aplication.Events;
using Aplication.Interfaces;
using Infraestructure.IntegrationCommand;
using MediatR;

namespace Infra.Events.Handlers
{
    public class ProductCreatedNotificationEventHandler
    : INotificationHandler<ProductCreatedNotificationEvent>
    {
        private readonly IRabbitPublisher _publisher;

        public ProductCreatedNotificationEventHandler(IRabbitPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task Handle(ProductCreatedNotificationEvent notification, CancellationToken cancellationToken)
        {
            var evt = new ProductCreatedIntegration(
            notification.name,
            notification.stock,
            notification.desposito,
            notification.id
            );

            await _publisher.Publish(evt);
        }
    }
}

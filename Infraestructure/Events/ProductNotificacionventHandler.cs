using aplication.Events;
using Infraestructure.Interfaces;
using MediatR;

namespace Infraestructure.Events
{
    public class ProductNotificacionventHandler
    : INotificationHandler<ProductNotificationEventModel>
    {
        private readonly IRabbitPublisherToInventario publisher_;

        public ProductNotificacionventHandler(IRabbitPublisherToInventario publisher)
        {
            publisher_ = publisher;
        }

        public async Task Handle(ProductNotificationEventModel notification, CancellationToken cancellationToken)
        {
            await publisher_.Publish(notification);
        }
    }
}

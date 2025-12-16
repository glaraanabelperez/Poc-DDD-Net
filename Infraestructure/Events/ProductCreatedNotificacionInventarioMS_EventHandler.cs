using Aplication.Events;
using Aplication.Interfaces;
using Aplication.ModelsIntegration;
using Infraestructure.IntegrationCommand;
using MediatR;

namespace Infraestructure.Events
{
    public class ProductCreatedNotificationInventarioEventHandler
    : INotificationHandler<ProductCreatedNotificationModel>
    {
        private readonly IRabbitPublisher publisher_;

        public ProductCreatedNotificationInventarioEventHandler(IRabbitPublisher publisher)
        {
            publisher_ = publisher;
        }

        public async Task Handle(ProductCreatedNotificationModel notification, CancellationToken cancellationToken)
        {
            var evt = new ProductCreatedIntegration( //faltaria notificar la cantidad
            notification.id
            );

            //Enviar email-
            await publisher_.Publish(evt);
        }
    }
}

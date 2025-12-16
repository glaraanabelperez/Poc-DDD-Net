using aplication.Events;
using Domain.Events;
using MediatR;

namespace Aplication.Events
{
    //recibir evento y con interfaz comunicarse con infra y con la iterfaz de rabbit

    public class ProductCreatedNotificationInventarioEventHandler
    : IRequestHandler<ProductNotificationInventarioEventModel>
    {
        private readonly IDomainEvent publisher_;

        public ProductCreatedNotificationInventarioEventHandler(IDomainEvent publisher)
        {
            publisher_ = publisher;
        }

        public async Task Handle(ProductNotificationInventarioEventModel notification, CancellationToken cancellationToken)
        {
            var evt = new ProductNotificationInventarioEventModel( //faltaria notificar la cantidad
            notification.id
            );

            //Enviar email-
            await publisher_.Publisher(evt);
        }
    }
}

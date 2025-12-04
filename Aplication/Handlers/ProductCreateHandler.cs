using Aplication.Commands.ProductCommands;
using Domain.Agregates;
using Domain.Repository;
using MediatR;
using Domain.Events;

namespace Aplication.Handlers
{
    public class ProductCreateHandler : IRequestHandler<ProductCreateCommand, Response>
    {
        public IRepository Repository { get; set; }
        public IMediator MediatorEvent { get; set; }
        public ProductCreateHandler(IMediator MediatorEvent_, IRepository repo)
        {
            Repository = repo;
            MediatorEvent = (Mediator)MediatorEvent_;   
        }
        public async Task<Response> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            Product prod = new Product(request.Name, request.Stock, request.desposito);
            Response res= await Repository.AddAsync(prod, cancellationToken);
            //foreach
            if (res.IsSuccess)
            {
                var evt = new ProductCreatedNotificationEvent(
                    prod.Name,
                    prod.Stock.Quantity,
                    prod.desposito,
                    prod.Id
                );

                await MediatorEvent.Publish(evt, cancellationToken);
            }
            return res;
        }
    }
}

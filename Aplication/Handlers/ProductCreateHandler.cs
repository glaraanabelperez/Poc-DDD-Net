using Aplication.Events;
using Aplication.Handlers.Command;
using Aplication.IRepository;
using Aplication.IService;
using Aplication.Models;
using Domain.Agregates;
using MediatR;

namespace Aplication.Handlers
{
    public class ProductCreateHandler : IRequestHandler<ProductCreateCommand, Response>
    {
        public IProductRepository Repository { get; set; }
        public IDepositoRepository Deposito { get; set; }
        public IProveedorService Proveedor { get; set; }

        public IMediator Mediator { get; set; }
        public ProductCreateHandler(
            IMediator MediatorEvent_,
            IProductRepository repo, 
            IDepositoRepository depo)
        {
            Repository = repo;
            Mediator = (Mediator)MediatorEvent_;   
            Deposito = depo;
        }
        public async Task<Response> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            bool proveedorExist_ = false;
            bool depositoExist_ = false;

            if (request.ProveedorId == 0 && request.Garantia)
                throw new ArgumentException("Se necesita el dato del proveedor si el producto tiene garantia.");

            //Validacione de datos
            if(request.Garantia)
                proveedorExist_ = await Existprovider(request.ProveedorId, cancellationToken);
            if(request.Garantia && !proveedorExist_)
                throw new ArgumentException($"El proveedor con Id {request.ProveedorId} no existe.");

            depositoExist_ = await ExistDeposito(request.Deposito , cancellationToken);

            if(!depositoExist_)
                throw new ArgumentException($"El deposito con Id {request.Deposito} no existe.");

            Product prod = new Product(request.Name, request.Serie, request.Stock, request.Deposito, request.Garantia, request.ProveedorId);
            
            ProductDto product = await Repository.Add(prod.serie);


            var evt = new ProductCreatedNotificationModel(
                 product.productId
             );

                Mediator.Publish(evt, cancellationToken); //Se publica a inventario que se creo un producto(media tr y rabbit)

            return new Response { IsSuccess=true };
        }

        private async Task<bool> ExistDeposito(long depositoId, CancellationToken cancellationToken)
        {
            bool res = await Deposito.ExistDepositoId(depositoId);
            return res;
        }

        private async Task<bool> Existprovider(long proveedorId, CancellationToken cancellationToken)
        {
           var result = await Proveedor.ExistProveedorId(proveedorId);
            return result;
            
        }
    }
}

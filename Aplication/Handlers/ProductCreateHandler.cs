using aplication.Events;
using Aplication.Handlers.Command;
using Aplication.IRepository;
using Aplication.Models;
using Domain.Agregates;
using MediatR;

namespace Aplication.Handlers
{
    public class ProductCreateHandler : IRequestHandler<ProductCreateCommand, Response>
    {
        private IProveedorRepository proveedor { get; set; }
        private IProductRepository Repository { get; set; }
        private IDepositoRepository Deposito { get; set; }
        private IMediator Mediator { get; set; }
        public ProductCreateHandler(IMediator MediatorEvent_,IProductRepository repo,IDepositoRepository depo, IProveedorRepository proveedor_)
        {
            proveedor = proveedor_;
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
            if(request.Garantia && !proveedorExist_) throw new ArgumentException($"El proveedor con Id {request.ProveedorId} no existe.");

            depositoExist_ = await ExistDeposito(request.Deposito , cancellationToken);
            if(!depositoExist_) throw new ArgumentException($"El deposito con Id {request.Deposito} no existe.");

            Product prod = new Product(request.Name, request.Serie, request.Stock, request.Deposito, request.Garantia, request.ProveedorId);            
            ProductDto product = await Repository.Add(prod.serie);

            //.send
            var evt = new ProductNotificationEventModel(
                 product.productId,
                 prod.Stock.Quantity
             );

            await Mediator.Publish(evt, cancellationToken); 

            return new Response { IsSuccess = true , Data = product };
        }

        private async Task<bool> ExistDeposito(long depositoId, CancellationToken cancellationToken)
        {
            bool res = await Deposito.ExistDepositoId(depositoId);
            return res;
        }

        private async Task<bool> Existprovider(long proveedorId, CancellationToken cancellationToken)
        {
           var result = await proveedor.ExistProveedorId(proveedorId);
            return result;
            
        }
    }
}

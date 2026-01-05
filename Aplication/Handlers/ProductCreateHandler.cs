using aplication.Events;
using Aplication.Dto;
using Aplication.Handlers.Command;
using Aplication.Interfaces;
using Aplication.Models;
using Domain.Agregates;
using MediatR;

namespace Aplication.Handlers
{
    public class ProductCreateHandler : IRequestHandler<ProductCreateCommand, Response>
    {
        private IProveedorService proveedorService_ { get; set; }
        private IProductRepository Repository { get; set; }
        private IDepositoService DepositoService_ { get; set; }
        private IMediator Mediator_ { get; set; }

        public ProductCreateHandler(IMediator MediatorEvent, IProductRepository repo, IDepositoService depoService, IProveedorService proveedorService)
        {
            proveedorService_ = proveedorService;
            Repository = repo;
            Mediator_ = MediatorEvent;
            DepositoService_ = depoService;
        }
       
        public async Task<Response> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {

            if (request.ProveedorId == 0 && request.Garantia)
                throw new ArgumentException("Se necesita el dato del proveedor si el producto tiene garantia.");

            //Validacione de datos
            await ValidacionGarantia(request.Garantia, request.ProveedorId);         
            await ExistDeposito(request.Deposito);

            Product prod = new Product(request.Name, request.Serie, request.Stock, request.Deposito, request.Garantia, request.ProveedorId);            
           
            try
            {
                ProductDto productDTO = await Repository.Add(prod);

                if(productDTO == null)
                    return new Response { IsSuccess = false, mesagge = "No se pudo crear el producto" };

                //Publicacion externa Producto creado
                var evt = new ProductNotificationEventModel(productDTO.productId, productDTO.stock);
                await Mediator_.Publish(evt, cancellationToken);

                return new Response { IsSuccess = true, Data = productDTO };
            }
            catch (Exception ex)
            {
                // Falta Loguear ex si procede
                return new Response { IsSuccess = false, mesagge = ex.Message };
            }

        }

        private async Task ValidacionGarantia(bool garantia, long proveedorId)
        {
            bool proveedorExist_ = false;
            if (garantia)
                proveedorExist_ = await proveedorService_.ExistProveedorId(proveedorId);
            if (garantia && !proveedorExist_) throw new ArgumentException($"Si el producto tiene garantia es necesario el identificador del proveedor");
        }
        private async Task ExistDeposito(long depositoId )
        {
            bool res = await DepositoService_.ExistDepositoId(depositoId);
            if (!res) throw new ArgumentException($"El deposito con Id {depositoId} no existe.");
        }

       
    }
}


using Domain.Agregates;
using MediatR;

namespace Aplication.Commands.ProductCommands
{
    public class ProductCreateCommand : IRequest<Response>
    {
        public long? Id { get;  set; }
        public string Name { get;  set; }
        public int Stock { get;  set; }
        public long desposito { get;  set; }
    }

}

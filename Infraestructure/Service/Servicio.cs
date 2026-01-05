using Aplication.Interfaces;

namespace Infraestructure.Service
{
    public class Servicio : IDepositoService, IProveedorService
    {       
        public void Llamadamicroservicio()
        {
            //Armado Url
            throw new NotImplementedException();
        }
        public Task<bool> ExistDepositoId(long id)
        {
            //llamada al servicio HTTP
            throw new NotImplementedException();
        }

        public Task<bool> ExistProveedorId(long proveedorId_)
        {
            throw new NotImplementedException();
        }
    }
}

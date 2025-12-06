using Domain.Agregates;
using Domain.Repository;
using Infraestricture.Persistencia.DBContext.AppDBContext;
using Microsoft.EntityFrameworkCore.Storage;


namespace Infraestructure.Repository
{
    public class ProductRepository : IRepository
    {
        //Inyeccion dbContext

        public  async Task<Response> AddAsync(Product product, CancellationToken cancellationToken)
        {
            Response res = new Response() { Data = product };

            //Persistencia

            return  res;
        }

        private object SetObjectToCreate(object request)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAsync(long productId)
        {
            throw new NotImplementedException();
        }
    }
}

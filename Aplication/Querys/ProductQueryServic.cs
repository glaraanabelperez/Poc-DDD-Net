using Domain.Agregates;

namespace Aplication.Querys
{
    public class ProductQueryServic : IProductQueryServic
    {
        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(long productId)
        {
            throw new NotImplementedException();
        }
    }
}

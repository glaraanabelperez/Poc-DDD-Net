
using Domain.Agregates;

namespace Aplication.Querys
{
    public interface IProductQueryServic
    {
        Task<Product> GetProductByIdAsync(long productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}

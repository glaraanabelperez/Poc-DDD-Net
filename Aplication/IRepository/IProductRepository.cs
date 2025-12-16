
using Aplication.Models;
namespace Aplication.IRepository
{
    public interface IProductRepository
    {
        Task<bool> ExistProductByCodioSerie(long serie);
        Task<ProductDto> Add(string productId);

    }
}

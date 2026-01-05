

using Aplication.Dto;

namespace Aplication.Interfaces
{
    public interface IProductRepository
    {
        public Task<bool> ExistProductByCodioSerie(string serie);
        public Task<ProductDto> Add(Domain.Agregates.Product product);

    }
}

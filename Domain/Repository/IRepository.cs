using Domain.Agregates;

namespace Domain.Repository
{
    public interface IRepository
    {
        public Task<Product> GetAsync(long productId);
        public Task<Response>  AddAsync(Product prod, CancellationToken cancellationToken);

    }
}
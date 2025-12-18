
using Aplication.IRepository;
using Aplication.Models;
using Infraestricture.Persistencia.DBContext.AppDBContext;

namespace Infraestructure.Querys
{
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ProductDto> Add(string productId)
        {

            throw new NotImplementedException();
        }

        Task<bool> IProductRepository.ExistProductByCodioSerie(long serie)
        {
            //var queryable = _context.Product
            //              .Contains(x => x.serie.Equals(serie));
            //return true;
            throw new NotImplementedException();
        }
    }
}

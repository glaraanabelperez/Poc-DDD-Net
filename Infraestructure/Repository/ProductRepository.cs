
using Aplication.Dto;
using Aplication.Interfaces;
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

        public async Task<ProductDto> Add(Domain.Agregates.Product product)
        {
            if (product is null) throw new ArgumentNullException(nameof(product));

            try
            {
                var entity = new Infraestructure.DBContext.Entidades.Product
                {
                    serie = product.serie,
                    //Completar mapeo de campos-
                };

                var entry = await _context.Product.AddAsync(entity);
                await _context.SaveChangesAsync();

                return new ProductDto
                {
                    productId = entry.Entity.id,
                    serie = entry.Entity.serie
                    // mapear más campos si hace falta
                };
            }
            catch (Exception dbEx)
            {
                // Loguear si tienes logger (no ocultes el error)
                throw new Exception("Error al guardar el producto en la base de datos.", dbEx);
            }
        }

        public async Task<bool> ExistProductByCodioSerie(string serie)
        {
            throw new NotImplementedException();
            //return await _context.Product.AnyAsync(p => p.serie.Equals(serie));       
        }

    }
}

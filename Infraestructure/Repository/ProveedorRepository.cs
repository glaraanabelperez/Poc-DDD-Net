using Aplication.IRepository;
using Infraestricture.Persistencia.DBContext.AppDBContext;

namespace Infraestructure.Repository
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly ApplicationDbContext _context;
        public ProveedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> ExistProveedorId(long id)
        {
            throw new NotImplementedException();
        }     

    }
}

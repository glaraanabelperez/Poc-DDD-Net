using Aplication.IRepository;
using Infraestricture.Persistencia.DBContext.AppDBContext;

namespace Infraestructure.Repository
{
    public class DepositoRepository : IDepositoRepository
    {
        private readonly ApplicationDbContext _context;
        public DepositoRepository(ApplicationDbContext context)
        {
        }

        public Task<bool> ExistDepositoId(long id)
        {
            throw new NotImplementedException();
        }     

    }
}

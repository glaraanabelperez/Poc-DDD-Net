
namespace Aplication.IRepository
{
    public interface IDepositoRepository
    {
        Task<bool> ExistDepositoId(long id);
    }
}

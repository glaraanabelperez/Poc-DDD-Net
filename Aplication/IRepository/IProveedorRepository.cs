
namespace Aplication.IRepository
{
    public interface IProveedorRepository
    {
        Task<bool> ExistProveedorId(long id);
    }
}

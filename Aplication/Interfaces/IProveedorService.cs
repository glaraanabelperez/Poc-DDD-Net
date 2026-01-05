namespace Aplication.Interfaces
{
    public interface IProveedorService
    {
        Task<bool> ExistProveedorId(long proveedorId_);
    }
}
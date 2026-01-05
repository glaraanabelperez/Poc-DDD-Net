namespace Aplication.Interfaces
{
    public interface IDepositoService
    {
        Task<bool> ExistDepositoId(long depositoId);
    }
}
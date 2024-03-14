namespace PacPay.Dominio.Interfaces
{
    public interface ICommitDados
    {
        Task Commit(CancellationToken cancellationToken);
    }
}
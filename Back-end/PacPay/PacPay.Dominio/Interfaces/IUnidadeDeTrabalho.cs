namespace PacPay.Dominio.Interfaces
{
    public interface IUnidadeDeTrabalho
    {
        Task Commit(CancellationToken cancellationToken);
    }
}
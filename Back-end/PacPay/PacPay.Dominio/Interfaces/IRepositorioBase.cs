namespace PacPay.Dominio.Interfaces
{
    public interface IRepositorioBase<T>
    {
        Task Adicionar(T entidade, CancellationToken cancellationToken);

        void Atualizar(T entidade, CancellationToken cancellationToken);

        void Excluir(T entidade, CancellationToken cancellationToken);
    }
}
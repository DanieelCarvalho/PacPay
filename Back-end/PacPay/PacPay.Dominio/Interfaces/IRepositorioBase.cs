namespace PacPay.Dominio.Interfaces
{
    public interface IRepositorioBase<T>
    {
        Task Adicionar(T entidade, CancellationToken cancellationToken);

        void Atualizar(T entidade);

        void Desativar(T entidade);

        void Reativar(T entidade);
    }
}
namespace PacPay.Dominio.Interfaces
{
    public interface IRepositorioBase<T>
    {
        void Adicionar(T entidade, CancellationToken cancellationToken);

        void Atualizar(T entidade);

        void Desativar(T entidade);

        void Reativar(T entidade);
    }
}
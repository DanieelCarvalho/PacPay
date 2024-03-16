namespace PacPay.Dominio.Interfaces
{
    public interface IRepositorioBase<T>
    {
        void Adicionar(T entidade, CancellationToken cancellationToken);

        void Atualizar(T entidade);

        void Excluir(T entidade);
    }
}
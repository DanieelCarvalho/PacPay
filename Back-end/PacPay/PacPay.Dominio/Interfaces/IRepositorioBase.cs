using PacPay.Dominio.Entidades;

namespace PacPay.Dominio.Interfaces
{
    public interface IRepositorioBase<T> where T : EntidadeBase
    {
        void Adicionar(T entidade);

        void Atualizar(T entidade);

        void Excluir(T entidade);

        Task<T?> BuscarComId(Guid numeroConta, CancellationToken cancellationToken);
    }
}
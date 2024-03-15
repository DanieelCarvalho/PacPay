using System.Threading;

namespace PacPay.Dominio.Interfaces
{
    public interface IRepositorioBase<T>
    {
        void Adicionar(T entidade, CancellationToken cancellationToken);

        void Atualizar(T entidade, CancellationToken cancellationToken);

        void Excluir(T entidade, CancellationToken cancellationToken);
    }
}
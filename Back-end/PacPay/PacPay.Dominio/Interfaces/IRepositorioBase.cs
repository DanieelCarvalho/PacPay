using PacPay.Dominio.Entidades;

namespace PacPay.Dominio.Interfaces
{
    public interface IRepositorioBase<T> where T : EntidadeBase
    {
        void Adicionar(T entidade);

        void Atualizar(T entidade);

        void Excluir(T entidade);

        Task<bool> ContaExiste(string documento, CancellationToken cancellationToken);

        Task<Conta> BuscarConta(string documento, CancellationToken cancellationToken);
    }
}
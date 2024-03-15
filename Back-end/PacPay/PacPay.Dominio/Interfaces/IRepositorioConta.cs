using PacPay.Dominio.Entidades;

namespace PacPay.Dominio.Interfaces
{
    public interface IRepositorioConta : IRepositorioBase<Conta>
    {
        Task<bool> ContaExiste(string cpf, CancellationToken cancellationToken);

        Task<Conta> BuscarConta(string cpf, CancellationToken cancellationToken);

        void Deposito(string cpf, decimal valor, string contaDestino, CancellationToken cancellationToken);
    }
}
using PacPay.Dominio.Entidades;

namespace PacPay.Dominio.Interfaces
{
    public interface IRepositorioConta : IRepositorioBase<Conta>
    {
        Task<bool> ContaExiste(string cpf, CancellationToken cancellationToken);

        Task<Conta> BuscarConta(string cpf, CancellationToken cancellationToken);

        Task<Conta> BuscarConta(Guid id, CancellationToken cancellationToken);

        Task<Conta?> BuscarCliente(Guid id, CancellationToken cancellationToken);

        Task<string?> PegarCpf(Guid id, CancellationToken cancellationToken);
    }
}
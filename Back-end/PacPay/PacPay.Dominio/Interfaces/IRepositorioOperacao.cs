using PacPay.Dominio.Entidades;

namespace PacPay.Dominio.Interfaces
{
    public interface IRepositorioOperacao
    {
        void Deposito(Operacao deposito, CancellationToken cancellationToken);
    }
}
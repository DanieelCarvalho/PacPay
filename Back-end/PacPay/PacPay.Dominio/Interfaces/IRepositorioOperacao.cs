using PacPay.Dominio.Entidades;

namespace PacPay.Dominio.Interfaces
{
    public interface IRepositorioOperacao
    {
        void Transacao(Operacao operacao);
    }
}
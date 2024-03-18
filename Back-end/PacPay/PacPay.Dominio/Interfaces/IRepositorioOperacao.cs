using PacPay.Dominio.Entidades;

namespace PacPay.Dominio.Interfaces
{
    public interface IRepositorioOperacao
    {
        void Transacao(Operacao operacao);

        List<Operacao> Historico(Guid id, int NumeroDaPagina, CancellationToken cancellationToken);
    }
}
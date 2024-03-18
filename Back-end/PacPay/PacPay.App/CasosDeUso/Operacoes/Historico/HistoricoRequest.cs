using MediatR;

namespace PacPay.App.CasosDeUso.Operacoes.Historico
{
    public sealed record HistoricoRequest(int NumeroDaPagina) : IRequest<List<HistoricoResponse>>
    {
    }
}
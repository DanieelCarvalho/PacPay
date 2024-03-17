using MediatR;

namespace PacPay.App.CasosDeUso.Operacoes.Transferencias
{
    public sealed record TransferenciaRequest(decimal Valor, string ContaDestino) : IRequest
    {
    }
}
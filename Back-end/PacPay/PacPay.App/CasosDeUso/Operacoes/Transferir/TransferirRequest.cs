using MediatR;

namespace PacPay.App.CasosDeUso.Operacoes.Transferir
{
    public sealed record TransferirRequest(decimal Valor, string ContaDestino, string? Descricao) : IRequest
    {
    }
}
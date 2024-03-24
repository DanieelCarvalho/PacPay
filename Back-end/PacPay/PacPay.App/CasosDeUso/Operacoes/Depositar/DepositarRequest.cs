using MediatR;

namespace PacPay.App.CasosDeUso.Operacoes.Depositar
{
    public sealed record DepositarRequest(decimal Valor, string? Descricao) : IRequest
    {
    }
}
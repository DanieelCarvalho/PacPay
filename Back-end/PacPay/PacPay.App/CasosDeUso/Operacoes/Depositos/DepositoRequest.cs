using MediatR;

namespace PacPay.App.CasosDeUso.Operacoes.Depositos
{
    public sealed record DepositoRequest(decimal Valor, string? Descricao) : IRequest
    {
    }
}
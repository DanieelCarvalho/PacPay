using MediatR;

namespace PacPay.App.CasosDeUso.Operacoes.Deposito
{
    public sealed record DepositoRequest(decimal Valor) : IRequest
    {
    }
}
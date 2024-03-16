using MediatR;

namespace PacPay.App.CasosDeUso.Operacoes.Saques
{
    public sealed record SaqueRequest(decimal Valor) : IRequest
    {
    }
}
using MediatR;

namespace PacPay.App.CasosDeUso.Operacoes.Sacar
{
    public sealed record SacarRequest(decimal Valor, string? Descricao) : IRequest
    {
    }
}
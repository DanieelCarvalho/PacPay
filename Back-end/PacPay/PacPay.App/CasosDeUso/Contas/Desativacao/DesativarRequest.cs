using MediatR;

namespace PacPay.App.CasosDeUso.Contas.Desativacao
{
    public sealed record DesativarRequest(string Senha) : IRequest<DesativarResponse>
    {
    }
}
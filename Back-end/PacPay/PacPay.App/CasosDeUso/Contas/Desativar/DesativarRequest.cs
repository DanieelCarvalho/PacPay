using MediatR;

namespace PacPay.App.CasosDeUso.Contas.Desativar
{
    public sealed record DesativarRequest(string Senha) : IRequest<DesativarResponse>
    {
    }
}
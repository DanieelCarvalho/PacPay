using MediatR;

namespace PacPay.App.CasosDeUso.Contas.Reativar
{
    public sealed record ReativarRequest(string Cpf, string Email, string Senha) : IRequest
    {
    }
}
using MediatR;

namespace PacPay.App.CasosDeUso.Contas.Reativacao
{
    public sealed record ReativarRequest(string Cpf, string Email, string Senha) : IRequest
    {
    }
}
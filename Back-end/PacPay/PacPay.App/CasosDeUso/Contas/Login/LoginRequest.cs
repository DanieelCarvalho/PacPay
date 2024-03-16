using MediatR;

namespace PacPay.App.CasosDeUso.AdicionarConta
{
    public sealed record LoginRequest(string Cpf, string Senha) : IRequest<LoginResponse>
    {
    }
}
using MediatR;

namespace PacPay.App.CasosDeUso.AdicionarConta
{
    public sealed record LoginRequest(string Documento, string Senha) : IRequest<LoginResponse>
    {
    }
}
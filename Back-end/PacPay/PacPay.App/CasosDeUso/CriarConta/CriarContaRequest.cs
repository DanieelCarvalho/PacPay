using MediatR;
using PacPay.Dominio.Entidades;

namespace PacPay.App.CasosDeUso.AdicionarConta
{
    public sealed record CriarContaRequest(Cliente Cliente, string Senha) : IRequest<CriarContaResponse>
    {
    }
}
using MediatR;
using PacPay.Dominio.Entidades;

namespace PacPay.App.CasosDeUso.Contas.CriarConta
{
    public sealed record CriarContaRequest(Cliente Cliente, string Senha) : IRequest<CriarContaResponse>
    {
    }
}
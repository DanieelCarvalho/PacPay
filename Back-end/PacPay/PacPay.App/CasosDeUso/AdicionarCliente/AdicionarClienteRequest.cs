using MediatR;
using PacPay.Dominio.Entidades;

namespace PacPay.App.CasosDeUso.AdicionarCliente
{
    public sealed record AdicionarClienteRequest(string Nome, string Documento, string Email, string Senha, string DataNascimento, Endereco Endereco) : IRequest<AdicionarClienteResponse>
    {
    }
}
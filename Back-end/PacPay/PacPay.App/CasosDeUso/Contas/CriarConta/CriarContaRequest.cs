using MediatR;

namespace PacPay.App.CasosDeUso.Contas.CriarConta
{
    public sealed record CriarContaRequest(string Senha, string Nome, string Cpf, string DataNascimento, string Telefone, string Email, string Cep, string Rua, string Cidade, string Estado, string? Numero, string? Complemento, string? Bairro, string? PontoDeReferencia) : IRequest
    {
    }
}
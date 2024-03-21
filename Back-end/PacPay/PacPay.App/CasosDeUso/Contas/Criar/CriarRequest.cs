using MediatR;

namespace PacPay.App.CasosDeUso.Contas.Criar
{
    public sealed record CriarRequest(string Senha, string Nome, string Cpf, string DataNascimento, string Telefone, string Email, string Cep, string Rua, string Cidade, string Estado, string? Numero, string? Complemento, string? Bairro, string? PontoDeReferencia) : IRequest
    {
    }
}
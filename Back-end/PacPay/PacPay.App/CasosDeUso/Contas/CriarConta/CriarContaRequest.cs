using MediatR;

namespace PacPay.App.CasosDeUso.Contas.CriarConta
{
    public sealed record CriarContaRequest(string Senha, string Nome, string Cpf, string DataNascimento, string Telefone, string Email, string Cep, string Rua, string Numero, string Complemento, string Bairro, string Cidade, string Estado, string PontoDeReferencia) : IRequest<CriarContaResponse>
    {
    }
}
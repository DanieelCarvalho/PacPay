using MediatR;

namespace PacPay.App.CasosDeUso.Contas.Atualizacao
{
    public sealed record AtualizarRequest(string? Senha, string? Nome, string? Cpf, string? DataNascimento, string? Telefone, string? Email, string? Cep, string? Rua, string? Cidade, string? Estado, string? Numero, string? Complemento, string? Bairro, string? PontoDeReferencia) : IRequest<AtualizarResponse>
    {
    }
}
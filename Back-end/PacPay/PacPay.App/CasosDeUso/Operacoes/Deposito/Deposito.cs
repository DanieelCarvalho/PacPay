using MediatR;
using Microsoft.AspNetCore.Http;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Operacoes.Deposito
{
    public class Deposito(IAutenticacao autenticacao, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados, IHttpContextAccessor httpContextAccessor) : IRequestHandler<DepositoRequest>
    {
        private readonly IAutenticacao _autenticacao = autenticacao;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly IRepositorioOperacao _repositorioOperacao = repositorioOperacao;
        private readonly ICommitDados _commitDados = commitDados;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public async Task Handle(DepositoRequest request, CancellationToken cancellationToken)
        {
            string token = _httpContextAccessor.HttpContext!.Request.Headers.Authorization!.Single()!.Split(" ").Last();

            Guid id = Guid.Parse(_autenticacao.PegarId(token));
            decimal valor = request.Valor;

            Conta conta = await _repositorioConta.BuscarConta(id, cancellationToken);
            Operacao deposito = new();

            deposito.Deposito(valor, conta, _repositorioConta, _repositorioOperacao, _commitDados, cancellationToken);
        }
    }
}
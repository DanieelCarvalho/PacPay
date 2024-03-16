using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Operacoes.Deposito
{
    public class Deposito(IAutenticacao autenticacao, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados) : IRequestHandler<DepositoRequest>
    {
        private readonly IAutenticacao _autenticacao = autenticacao;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly IRepositorioOperacao _repositorioOperacao = repositorioOperacao;
        private readonly ICommitDados _commitDados = commitDados;

        public async Task Handle(DepositoRequest request, CancellationToken cancellationToken)
        {
            Guid id = Guid.Parse(_autenticacao.PegarId());
            await Console.Out.WriteLineAsync("asdasdadsasd awqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq");
            decimal valor = request.Valor;

            Conta conta = await _repositorioConta.BuscarConta(id, cancellationToken);
            Operacao Operacao = new();

            Operacao.Deposito(valor, conta, _repositorioConta, _repositorioOperacao, _commitDados, cancellationToken);
        }
    }
}
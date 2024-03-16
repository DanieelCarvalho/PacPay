using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces.IUtilitarios;
using PacPay.Dominio.Interfaces;

namespace PacPay.App.CasosDeUso.Operacoes.Saques
{
    public class Saque(IAutenticacao autenticacao, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados) : IRequestHandler<SaqueRequest>
    {
        private readonly IAutenticacao _autenticacao = autenticacao;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly IRepositorioOperacao _repositorioOperacao = repositorioOperacao;
        private readonly ICommitDados _commitDados = commitDados;

        public async Task Handle(SaqueRequest request, CancellationToken cancellationToken)
        {
            Guid id = Guid.Parse(_autenticacao.PegarId());
            decimal valor = request.Valor;

            Conta conta = await _repositorioConta.BuscarConta(id, cancellationToken);
            Operacao Operacao = new();

            Operacao.Saque(valor, conta, _repositorioConta, _repositorioOperacao, _commitDados, cancellationToken);
        }
    }
}
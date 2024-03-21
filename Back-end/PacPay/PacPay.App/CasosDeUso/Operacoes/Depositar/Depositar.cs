using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Operacoes.Depositar
{
    public sealed class Depositar(IAutenticador autenticador, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados) : IRequestHandler<DepositarRequest>
    {
        private readonly IAutenticador _autenticador = autenticador;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly IRepositorioOperacao _repositorioOperacao = repositorioOperacao;
        private readonly ICommitDados _commitDados = commitDados;

        public async Task Handle(DepositarRequest request, CancellationToken cancellationToken)
        {
            FluentValidation.Results.ValidationResult resultado = new DepositarValidador().Validate(request);
            if (!resultado.IsValid) throw new FluentValidation.ValidationException(resultado.Errors);

            Guid id = Guid.Parse(_autenticador.PegarId());
            decimal valor = request.Valor;
            string? descricao = request.Descricao;

            Conta conta = await _repositorioConta.BuscarConta(id, cancellationToken);
            Operacao Operacao = new();

            Operacao.Deposito(valor, descricao, conta, _repositorioConta, _repositorioOperacao, _commitDados, cancellationToken);
        }
    }
}
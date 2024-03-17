using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Operacoes.Depositos
{
    public sealed class Deposito(IAutenticacao autenticacao, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados) : IRequestHandler<DepositoRequest>
    {
        private readonly IAutenticacao _autenticacao = autenticacao;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly IRepositorioOperacao _repositorioOperacao = repositorioOperacao;
        private readonly ICommitDados _commitDados = commitDados;

        public async Task Handle(DepositoRequest request, CancellationToken cancellationToken)
        {
            FluentValidation.Results.ValidationResult resultado = new DepositoValidador().Validate(request);
            if (!resultado.IsValid) throw new FluentValidation.ValidationException(resultado.Errors);

            Guid id = Guid.Parse(_autenticacao.PegarId());
            decimal valor = request.Valor;

            Conta conta = await _repositorioConta.BuscarConta(id, cancellationToken);
            Operacao Operacao = new();

            Operacao.Deposito(valor, conta, _repositorioConta, _repositorioOperacao, _commitDados, cancellationToken);
        }
    }
}
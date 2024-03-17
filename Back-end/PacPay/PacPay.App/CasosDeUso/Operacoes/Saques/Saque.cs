using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces.IUtilitarios;
using PacPay.Dominio.Interfaces;

namespace PacPay.App.CasosDeUso.Operacoes.Saques
{
    public sealed class Saque(IAutenticacao autenticacao, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados) : IRequestHandler<SaqueRequest>
    {
        private readonly IAutenticacao _autenticacao = autenticacao;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly IRepositorioOperacao _repositorioOperacao = repositorioOperacao;
        private readonly ICommitDados _commitDados = commitDados;

        public async Task Handle(SaqueRequest request, CancellationToken cancellationToken)
        {
            FluentValidation.Results.ValidationResult resultado = new SaqueValidador().Validate(request);
            if (!resultado.IsValid) throw new FluentValidation.ValidationException(resultado.Errors);

            Guid id = Guid.Parse(_autenticacao.PegarId());
            decimal valor = request.Valor;
            string? descricao = request.Descricao;

            Conta conta = await _repositorioConta.BuscarConta(id, cancellationToken);
            Operacao Operacao = new();

            Operacao.Saque(valor, descricao, conta, _repositorioConta, _repositorioOperacao, _commitDados, cancellationToken);
        }
    }
}
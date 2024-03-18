using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Operacoes.Transferencias
{
    public sealed class Transferencia(IAutenticacao autenticacao, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados) : IRequestHandler<TransferenciaRequest>
    {
        private readonly IAutenticacao _autenticacao = autenticacao;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly IRepositorioOperacao _repositorioOperacao = repositorioOperacao;
        private readonly ICommitDados _commitDados = commitDados;

        public async Task Handle(TransferenciaRequest request, CancellationToken cancellationToken)
        {
            FluentValidation.Results.ValidationResult resultado = new TransferenciaValidador().Validate(request);
            if (!resultado.IsValid) throw new FluentValidation.ValidationException(resultado.Errors);

            decimal valor = request.Valor;
            string? descricao = request.Descricao;

            Guid id = Guid.Parse(_autenticacao.PegarId());

            Conta contaOrigem = await _repositorioConta.BuscarConta(id, cancellationToken);

            Conta contaDestino = await _repositorioConta.BuscarConta(request.ContaDestino, cancellationToken);

            Operacao operacao = new();
            operacao.Transferencia(valor, descricao, contaOrigem, contaDestino, _repositorioConta, _repositorioOperacao, _commitDados, cancellationToken);
        }
    }
}
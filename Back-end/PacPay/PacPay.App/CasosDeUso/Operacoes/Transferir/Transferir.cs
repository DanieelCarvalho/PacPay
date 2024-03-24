using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Excecoes.Mensagens;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Operacoes.Transferir
{
    public sealed class Transferir(IAutenticador autenticador, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados) : IRequestHandler<TransferirRequest>
    {
        private readonly IAutenticador _autenticador = autenticador;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly IRepositorioOperacao _repositorioOperacao = repositorioOperacao;
        private readonly ICommitDados _commitDados = commitDados;

        public async Task Handle(TransferirRequest request, CancellationToken cancellationToken)
        {
            FluentValidation.Results.ValidationResult resultado = new TransferirValidador().Validate(request);
            if (!resultado.IsValid) throw new FluentValidation.ValidationException(resultado.Errors);

            decimal valor = request.Valor;
            string? descricao = request.Descricao;

            Guid id = Guid.Parse(_autenticador.PegarId());

            Conta contaOrigem = await _repositorioConta.BuscarConta(id, cancellationToken) ?? throw ContaErr.ContaNaoEncontrada404;

            Conta contaDestino = await _repositorioConta.BuscarConta(request.ContaDestino, cancellationToken) ?? throw ContaErr.ContaNaoEncontrada404;

            new Operacao().Transferencia(valor, descricao, contaOrigem, contaDestino, _repositorioConta, _repositorioOperacao, _commitDados, cancellationToken);
        }
    }
}
using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Excecoes.Mensagens;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Contas.Reativar
{
    public sealed class Reativar(IRepositorioConta repositorioConta, ICommitDados commitDados, IEncriptador encriptador) : IRequestHandler<ReativarRequest>
    {
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly ICommitDados _commitDados = commitDados;
        private readonly IEncriptador _encriptador = encriptador;

        public async Task Handle(ReativarRequest request, CancellationToken cancellationToken)
        {
            FluentValidation.Results.ValidationResult resultado = new ReativarValidador().Validate(request);
            if (!resultado.IsValid) throw new FluentValidation.ValidationException(resultado.Errors);

            Conta conta = await _repositorioConta.BuscarConta(request.Cpf, cancellationToken) ?? throw ContaErr.ContaNaoEncontrada404;

            conta.Reativar(request.Cpf, request.Email, request.Senha, _repositorioConta, _encriptador, _commitDados, cancellationToken);
        }
    }
}
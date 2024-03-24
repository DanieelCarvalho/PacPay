using AutoMapper;
using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Excecoes.Mensagens;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Contas.Atualizar
{
    public sealed class Atualizar(IMapper mapper, IAutenticador autenticador, IRepositorioConta repositorioConta, ICommitDados commitDados, IEncriptador encriptador) : IRequestHandler<AtualizarRequest>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAutenticador _autenticador = autenticador;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly ICommitDados _commitDados = commitDados;
        private readonly IEncriptador _encriptador = encriptador;

        public async Task Handle(AtualizarRequest request, CancellationToken cancellationToken)
        {
            FluentValidation.Results.ValidationResult resultado = new AtualizarValidador().Validate(request);
            if (!resultado.IsValid) throw new FluentValidation.ValidationException(resultado.Errors);

            Guid id = Guid.Parse(_autenticador.PegarId());

            Conta conta = await _repositorioConta.BuscarConta(id, cancellationToken) ?? throw ContaErr.ContaNaoEncontrada404;

            Conta.AtualizarValidador(request.Cpf, _repositorioConta, cancellationToken);

            _mapper.Map(request, conta);

            conta.Atualizar(request.Senha, _repositorioConta, _encriptador, _commitDados, cancellationToken);
        }
    }
}
using AutoMapper;
using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Excecoes;
using PacPay.Dominio.Excecoes.Mensagens;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Contas.Atualizacao
{
    public sealed class Atualizar(IMapper mapper, IAutenticacao autenticacao, IRepositorioConta repositorioConta, ICommitDados commitDados, IEncriptador encriptador) : IRequestHandler<AtualizarRequest, AtualizarResponse>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAutenticacao _autenticacao = autenticacao;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly ICommitDados _commitDados = commitDados;
        private readonly IEncriptador _encriptador = encriptador;

        public async Task<AtualizarResponse> Handle(AtualizarRequest request, CancellationToken cancellationToken)
        {
            FluentValidation.Results.ValidationResult resultado = new AtualizarValidador().Validate(request);
            if (!resultado.IsValid) throw new FluentValidation.ValidationException(resultado.Errors);

            Guid id = Guid.Parse(_autenticacao.PegarId());
            if (request.Cpf != null && await _repositorioConta.ContaExiste(request.Cpf, cancellationToken)) throw new AppExcecao(ContaErr.ContaJaExiste);

            Conta conta = await _repositorioConta.BuscarConta(id, cancellationToken);

            _mapper.Map(request, conta);

            if (request.Senha != null) conta.Senha = _encriptador.Encriptar(request.Senha);

            conta.AtualizarConta(_repositorioConta, _commitDados, cancellationToken);

            return new AtualizarResponse
            {
                Mensagem = "Conta atualizada com sucesso!"
            };
        }
    }
}
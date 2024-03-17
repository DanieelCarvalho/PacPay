using AutoMapper;
using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Contas.CriarConta
{
    public class CriarConta(IMapper mapper, IRepositorioConta repositorioConta, ICommitDados commitDados, IEncriptador encriptador) : IRequestHandler<CriarContaRequest>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly ICommitDados _commitDados = commitDados;
        private readonly IEncriptador _encriptador = encriptador;

        public async Task Handle(CriarContaRequest request, CancellationToken cancellationToken)

        {
            FluentValidation.Results.ValidationResult resultado = new CriarContaValidador().Validate(request);
            if (!resultado.IsValid) throw new FluentValidation.ValidationException(resultado.Errors);

            Conta conta = _mapper.Map<Conta>(request);

            await conta.RegistrarConta(_encriptador, _repositorioConta, _commitDados, cancellationToken);
        }
    }
}
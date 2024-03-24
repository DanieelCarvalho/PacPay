using AutoMapper;
using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Contas.Criar
{
    public class Criar(IMapper mapper, IRepositorioConta repositorioConta, ICommitDados commitDados, IEncriptador encriptador) : IRequestHandler<CriarRequest>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly ICommitDados _commitDados = commitDados;
        private readonly IEncriptador _encriptador = encriptador;

        public async Task Handle(CriarRequest request, CancellationToken cancellationToken)

        {
            FluentValidation.Results.ValidationResult resultado = new CriarValidador().Validate(request);
            if (!resultado.IsValid) throw new FluentValidation.ValidationException(resultado.Errors);

            Conta conta = _mapper.Map<Conta>(request);

            await conta.Registrar(_encriptador, _repositorioConta, _commitDados, cancellationToken);
        }
    }
}
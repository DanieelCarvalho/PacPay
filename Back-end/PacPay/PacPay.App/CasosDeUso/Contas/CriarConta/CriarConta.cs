using AutoMapper;
using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Contas.CriarConta
{
    public class CriarConta(IMapper mapper, IRepositorioConta repositorioConta, ICommitDados commitDados, IEncriptador encriptador) : IRequestHandler<CriarContaRequest, CriarContaResponse>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly ICommitDados _commitDados = commitDados;
        private readonly IEncriptador _encriptador = encriptador;

        public async Task<CriarContaResponse> Handle(CriarContaRequest request, CancellationToken cancellationToken)
        {
            Conta conta = _mapper.Map<Conta>(request);

            await conta.RegistrarConta(_encriptador, _repositorioConta, _commitDados, cancellationToken);

            return _mapper.Map<CriarContaResponse>(conta);
        }
    }
}
using AutoMapper;
using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Contas.CriarConta
{
    public class CriarConta(ICommitDados commitDados, IRepositorioConta repositorioConta, IMapper mapper, IEncriptador encriptador) : IRequestHandler<CriarContaRequest, CriarContaResponse>
    {
        private readonly ICommitDados _commitDados = commitDados;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly IMapper _mapper = mapper;
        private readonly IEncriptador _encriptador = encriptador;

        public async Task<CriarContaResponse> Handle(CriarContaRequest request, CancellationToken cancellationToken)
        {
            Conta conta = _mapper.Map<Conta>(request);

            conta.Senha = _encriptador.Encriptar(request.Senha);

            _repositorioConta.Adicionar(conta, cancellationToken);

            await _commitDados.Commit(cancellationToken);

            return _mapper.Map<CriarContaResponse>(conta);
        }
    }
}
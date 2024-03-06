using AutoMapper;
using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.AdicionarConta
{
    public class CriarConta(IUnidadeDeTrabalho unidadeDeTrabalho, IRepositorioConta repositorioConta, IMapper mapper, IEncriptador encriptador) : IRequestHandler<CriarContaRequest, CriarContaResponse>
    {
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho = unidadeDeTrabalho;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly IMapper _mapper = mapper;
        private readonly IEncriptador _encriptador = encriptador;

        public async Task<CriarContaResponse> Handle(CriarContaRequest request, CancellationToken cancellationToken)
        {
            Conta conta = _mapper.Map<Conta>(request);

            bool contaExiste = await _repositorioConta.ContaEsxiste(conta.Cliente.Documento, cancellationToken);

            if (contaExiste) throw new Exception("Conta já existe");

            conta.Senha = _encriptador.Encriptar(request.Senha);

            _repositorioConta.Adicionar(conta);

            await _unidadeDeTrabalho.Commit(cancellationToken);

            return _mapper.Map<CriarContaResponse>(conta);
        }
    }
}
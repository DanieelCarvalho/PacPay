using PacPay.Dominio.Interfaces.IUtilitarios;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Entidades;
using AutoMapper;
using MediatR;

namespace PacPay.App.CasosDeUso.Contas.Buscar
{
    public sealed class Busca(IMapper mapper, IAutenticacao autenticacao, IRepositorioConta repositorioConta) : IRequestHandler<BuscaRequest, BuscaResponse>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAutenticacao _autenticacao = autenticacao;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;

        public async Task<BuscaResponse> Handle(BuscaRequest reques, CancellationToken cancellationToken)
        {
            Guid id = Guid.Parse(_autenticacao.PegarId());
            Conta cliente = await _repositorioConta.BuscarCliente(id, cancellationToken) ?? throw new Exception("Cliente não encontrado");
            BuscaResponse response = _mapper.Map<BuscaResponse>(cliente);
            response.DataDeCriacao = cliente.DataCriacao.ToLocalTime().ToString("dd/MM/yyyy HH:mm:hh");

            return response;
        }
    }
}
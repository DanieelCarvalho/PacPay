using PacPay.Dominio.Interfaces.IUtilitarios;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Entidades;
using AutoMapper;
using MediatR;

namespace PacPay.App.CasosDeUso.Contas.Buscar
{
    public sealed class Buscar(IMapper mapper, IAutenticador autenticador, IRepositorioConta repositorioConta) : IRequestHandler<BuscarRequest, BuscarResponse>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAutenticador _autenticador = autenticador;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;

        public async Task<BuscarResponse> Handle(BuscarRequest request, CancellationToken cancellationToken)
        {
            Guid id = Guid.Parse(_autenticador.PegarId());
            Conta cliente = await _repositorioConta.BuscarCliente(id, cancellationToken) ?? throw new Exception("Cliente não encontrado");
            BuscarResponse response = _mapper.Map<BuscarResponse>(cliente);
            response.DataDeCriacao = cliente.DataCriacao.ToLocalTime().ToString("dd/MM/yyyy HH:mm:hh");

            return response;
        }
    }
}
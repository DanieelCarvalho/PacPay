using PacPay.Dominio.Interfaces.IUtilitarios;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Entidades;
using AutoMapper;
using MediatR;
using PacPay.App.Compartilhado.Utilitarios;
using PacPay.Dominio.Excecoes.Mensagens;

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
            Conta cliente = await _repositorioConta.BuscarCliente(id, cancellationToken) ?? throw ContaErr.ContaNaoEncontrada404;
            if(cliente.Ativa == false) throw ContaErr.ContaDesativada403;
            BuscarResponse response = _mapper.Map<BuscarResponse>(cliente);
            response.DataDeCriacao = FormatarData.ParaString(cliente.DataCriacao);

            return response;
        }
    }
}
using AutoMapper;
using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;

namespace PacPay.App.CasosDeUso.AdicionarCliente
{
    public class AdicionarCliente(IUnidadeDeTrabalho unidadeDeTrabalho, IRepositorioCliente repositorioCliente, IMapper mapper) : IRequestHandler<AdicionarClienteRequest, AdicionarClienteResponse>
    {
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho = unidadeDeTrabalho;
        private readonly IRepositorioCliente _repositorioCliente = repositorioCliente;
        private readonly IMapper _mapper = mapper;

        public async Task<AdicionarClienteResponse> Handle(AdicionarClienteRequest request, CancellationToken cancellationToken)
        {
            Cliente cliente = _mapper.Map<Cliente>(request);

            _repositorioCliente.Adicionar(cliente);

            await _unidadeDeTrabalho.Commit(cancellationToken);

            return _mapper.Map<AdicionarClienteResponse>(cliente);
        }
    }
}
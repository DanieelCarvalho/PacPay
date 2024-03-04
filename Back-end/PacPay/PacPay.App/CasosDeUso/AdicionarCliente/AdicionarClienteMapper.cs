using AutoMapper;
using PacPay.Dominio.Entidades;

namespace PacPay.App.CasosDeUso.AdicionarCliente
{
    public sealed class AdicionarClienteMapper : Profile
    {
        public AdicionarClienteMapper()
        {
            CreateMap<AdicionarClienteRequest, Cliente>();
            CreateMap<Cliente, AdicionarClienteResponse>();
        }
    }
}
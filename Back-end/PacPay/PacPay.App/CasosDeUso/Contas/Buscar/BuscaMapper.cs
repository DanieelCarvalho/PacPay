using AutoMapper;
using PacPay.Dominio.Entidades;

namespace PacPay.App.CasosDeUso.Contas.Buscar
{
    public sealed class BuscaMapper : Profile
    {
        public BuscaMapper()
        {
            CreateMap<Conta, BuscaResponse>()
                .ForMember(x => x.Nome, opt => opt.MapFrom(x => x.Cliente.Nome))
                .ForMember(x => x.Cpf, opt => opt.MapFrom(x => x.Cliente.Cpf))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Cliente.Email))
                .ForMember(x => x.Saldo, opt => opt.MapFrom(x => x.Saldo))
                .ForMember(x => x.DataDeCriacao, opt => opt.MapFrom(x => x.DataCriacao));
        }
    }
}
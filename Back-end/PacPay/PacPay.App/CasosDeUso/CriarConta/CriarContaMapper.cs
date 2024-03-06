using AutoMapper;
using PacPay.Dominio.Entidades;

namespace PacPay.App.CasosDeUso.AdicionarConta
{
    public sealed class CriarContaMapper : Profile
    {
        public CriarContaMapper()
        {
            CreateMap<CriarContaRequest, Conta>();
            CreateMap<Conta, CriarContaResponse>().ForMember(x => x.Nome, opt => opt.MapFrom(x => x.Cliente.Nome))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Cliente.Email));
        }
    }
}
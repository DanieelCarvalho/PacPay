using AutoMapper;
using PacPay.Dominio.Entidades;

namespace PacPay.App.CasosDeUso.Contas.Atualizar
{
    public sealed class AtualizarMapper : Profile
    {
        public AtualizarMapper()
        {
            CreateMap<AtualizarRequest, Conta>()
                .ForMember(x => x.Senha, opt =>
                {
                    opt.Condition(src => src.Senha != null);
                    opt.MapFrom(x => x.Senha);
                })
                 .ForPath(x => x.Cliente.Nome, opt =>
                 {
                     opt.Condition(src => !string.IsNullOrEmpty(src.SourceMember));
                     opt.MapFrom(x => x.Nome);
                 })
                .ForPath(x => x.Cliente.Cpf, opt =>
                {
                    opt.Condition(src => !string.IsNullOrEmpty(src.SourceMember));
                    opt.MapFrom(x => x.Cpf);
                })
                .ForPath(x => x.Cliente.DataNascimento, opt =>
                {
                    opt.Condition(src => !string.IsNullOrEmpty(src.SourceMember));
                    opt.MapFrom(x => x.DataNascimento);
                })
                .ForPath(x => x.Cliente.Telefone, opt =>
                {
                    opt.Condition(src => !string.IsNullOrEmpty(src.SourceMember));
                    opt.MapFrom(x => x.Telefone);
                })
                .ForPath(x => x.Cliente.Email, opt =>
                {
                    opt.Condition(src => !string.IsNullOrEmpty(src.SourceMember));
                    opt.MapFrom(x => x.Email);
                })
                .ForPath(x => x.Cliente.Endereco.Cep, opt =>
                {
                    opt.Condition(src => !string.IsNullOrEmpty(src.SourceMember));
                    opt.MapFrom(x => x.Cep);
                })
                .ForPath(x => x.Cliente.Endereco.Rua, opt =>
                {
                    opt.Condition(src => !string.IsNullOrEmpty(src.SourceMember));
                    opt.MapFrom(x => x.Rua);
                })
                .ForPath(x => x.Cliente.Endereco.Numero, opt =>
                {
                    opt.Condition(src => !string.IsNullOrEmpty(src.SourceMember));
                    opt.MapFrom(x => x.Numero);
                })
                .ForPath(x => x.Cliente.Endereco.Complemento, opt =>
                {
                    opt.Condition(src => !string.IsNullOrEmpty(src.SourceMember));
                    opt.MapFrom(x => x.Complemento);
                })
                .ForPath(x => x.Cliente.Endereco.Bairro, opt =>
                {
                    opt.Condition(src => !string.IsNullOrEmpty(src.SourceMember));
                    opt.MapFrom(x => x.Bairro);
                })
                .ForPath(x => x.Cliente.Endereco.Cidade, opt =>
                {
                    opt.Condition(src => !string.IsNullOrEmpty(src.SourceMember));
                    opt.MapFrom(x => x.Cidade);
                })
                .ForPath(x => x.Cliente.Endereco.Estado, opt =>
                {
                    opt.Condition(src => !string.IsNullOrEmpty(src.SourceMember));
                    opt.MapFrom(x => x.Estado);
                })
                .ForPath(x => x.Cliente.Endereco.PontoDeReferencia, opt =>
                {
                    opt.Condition(src => !string.IsNullOrEmpty(src.SourceMember));
                    opt.MapFrom(x => x.PontoDeReferencia);
                });
        }
    }
}
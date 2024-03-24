using AutoMapper;
using PacPay.Dominio.Entidades;

namespace PacPay.App.CasosDeUso.Contas.Criar
{
    public sealed class CriarMapper : Profile
    {
        public CriarMapper()
        {
            CreateMap<CriarRequest, Conta>()
                .ForMember(x => x.Senha, opt => opt.MapFrom(x => x.Senha))
                .ForMember(x => x.Cliente, opt => opt.MapFrom(x => new Cliente
                {
                    Nome = x.Nome,
                    Cpf = x.Cpf,
                    DataNascimento = x.DataNascimento,
                    Telefone = x.Telefone,
                    Email = x.Email,
                    Endereco = new Endereco
                    {
                        Cep = x.Cep,
                        Rua = x.Rua,
                        Numero = x.Numero,
                        Complemento = x.Complemento,
                        Bairro = x.Bairro,
                        Cidade = x.Cidade,
                        Estado = x.Estado,
                        PontoDeReferencia = x.PontoDeReferencia
                    }
                }));
        }
    }
}
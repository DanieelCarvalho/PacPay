using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PacPay.App.Compartilhado.Utilitarios;
using PacPay.Dominio.Interfaces.IUtilitarios;
using System.Reflection;

namespace PacPay.App.Servicos
{
    public static class ExtensoesServico
    {
        public static void ConfiguraAplicacaoApp(this IServiceCollection servicos)
        {
            servicos.AddAutoMapper(typeof(ExtensoesServico));
            servicos.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            servicos.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            servicos.AddScoped<IEncriptador, Encriptador>();
            servicos.AddScoped<IAutenticacao, Autenticacao>();
        }
    }
}
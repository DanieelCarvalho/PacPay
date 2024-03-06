using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PacPay.App.Compartilhado.Comportamento;
using PacPay.App.Compartilhado.Utilitarios;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;
using System.Reflection;

namespace CleanArchitectureTraining.Application.Services
{
    public static class ExtensoesServico
    {
        public static void ConfiguraAplicacaoApp(this IServiceCollection servicos)
        {
            servicos.AddAutoMapper(typeof(ExtensoesServico));
            servicos.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            servicos.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            servicos.AddTransient(typeof(IPipelineBehavior<,>), typeof(ComportamentoDeValidacaor<,>));
            servicos.AddScoped<IEncriptador, Encriptador>();
        }
    }
}
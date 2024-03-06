using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PacPay.Dominio.Interfaces;
using PacPay.Infra.Contexto;
using PacPay.Infra.Repositorio;

namespace PacPay.Infra
{
    public static class ExtensoesServico
    {
        public static void ConfiguraInfraApp(this IServiceCollection servicos, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("sql");

            servicos.AddDbContext<AppDbContexto>(options =>
            {
                options.UseSqlite(connectionString);
            });

            servicos.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
            servicos.AddScoped<IRepositorioConta, RepositorioConta>();
        }
    }
}
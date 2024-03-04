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
        public static void ConfiguraInfraApp(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContexto>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
            services.AddScoped<IRepositorioCliente, RepositorioCliente>();
        }
    }
}
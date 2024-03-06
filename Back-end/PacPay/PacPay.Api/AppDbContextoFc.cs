using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PacPay.Infra.Contexto;

namespace PacPay.Api
{
    public class AppDbContextoFc : IDesignTimeDbContextFactory<AppDbContexto>
    {
        public AppDbContexto CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
            .Build();

            var builder = new DbContextOptionsBuilder<AppDbContexto>()
             .UseSqlite(config.GetConnectionString("sql"));

            return new AppDbContexto(builder.Options);
        }
    }
}
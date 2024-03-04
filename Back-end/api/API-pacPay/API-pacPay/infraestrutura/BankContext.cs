using API_pacPay.Domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API_pacPay.infraestrutura
{
    public class BankContext : DbContext
    {
        public DbSet<User> Usuario { get; set; }

        public DbSet<Address> Endereco { get; set; }

        private readonly IConfiguration _configuration;

        public BankContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Obtém a string de conexão do arquivo appsettings.json
                string connectionString = _configuration.GetConnectionString("PacPayServer");

                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        
    }
}

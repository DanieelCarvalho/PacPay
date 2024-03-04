using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PacPay.Dominio.Entidades;

namespace PacPay.Infra.Contexto
{
    public class AppDbContexto : DbContext
    {
        public AppDbContexto(DbContextOptions<AppDbContexto> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Saque> Saques { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(c => c.NumeroConta);
            modelBuilder.Entity<Admin>().HasKey(c => c.NumeroConta);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PacPay.Dominio.Entidades;

namespace PacPay.Infra.Contexto
{
    public class AppDbContexto(DbContextOptions<AppDbContexto> options) : DbContext(options)
    {
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Saque> Saques { get; set; }
        public DbSet<Deposito> Depositos { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
    }
}
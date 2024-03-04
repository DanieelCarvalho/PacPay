using Microsoft.EntityFrameworkCore;
using PacPay.Dominio.Entidades;

namespace PacPay.Infra.Contexto
{
    public class AppDbContexto(DbContextOptions<AppDbContexto> options) : DbContext(options)
    {
        public DbSet<Admin> Admin { get; private set; }
        public DbSet<Cliente> Clientes { get; private set; }
    }
}
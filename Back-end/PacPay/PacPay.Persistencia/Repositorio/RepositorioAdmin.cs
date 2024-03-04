using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Infra.Contexto;

namespace PacPay.Infra.Repositorio
{
    public class RepositorioAdmin : RepositorioBase<Admin>, IRepositorioAdmin
    {
        public RepositorioAdmin(AppDbContexto contexto) : base(contexto)
        {
        }
    }
}
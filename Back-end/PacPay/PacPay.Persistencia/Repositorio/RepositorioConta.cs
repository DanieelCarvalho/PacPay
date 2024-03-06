using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Infra.Contexto;

namespace PacPay.Infra.Repositorio
{
    public class RepositorioConta : RepositorioBase<Conta>, IRepositorioConta
    {
        public RepositorioConta(AppDbContexto contexto) : base(contexto)
        {
        }
    }
}
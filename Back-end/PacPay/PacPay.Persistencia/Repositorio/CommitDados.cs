using PacPay.Dominio.Interfaces;
using PacPay.Infra.Contexto;

namespace PacPay.Infra.Repositorio
{
    public sealed class CommitDados(AppDbContexto context) : ICommitDados
    {
        private readonly AppDbContexto _contexto = context;

        public async Task Commit(CancellationToken cancellationToken)
        {
            await _contexto.SaveChangesAsync(cancellationToken);
        }
    }
}
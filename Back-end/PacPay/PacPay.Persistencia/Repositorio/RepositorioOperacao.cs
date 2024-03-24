using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Infra.Contexto;

namespace PacPay.Infra.Repositorio
{
    public sealed class RepositorioOperacao<T>(AppDbContexto contexto) : IRepositorioOperacao where T : Operacao
    {
        private readonly AppDbContexto Contexto = contexto;

        public List<Operacao> Historico(Guid id, int NumeroDaPagina, CancellationToken cancellationToken)
        {
            int tamanho = 10;
            int skip = (NumeroDaPagina - 1) * tamanho;

            List<Operacao> operacoes = [.. Contexto.Operacoes
                .Where(x => x.IdContaOrigem == id)
                .OrderByDescending(x => x.DataOperacao)
                .Skip(skip)
                .Take(tamanho)];

            return operacoes;
        }

        public void Transacao(Operacao deposito)
        {
            Contexto.Add(deposito);
        }
    }
}
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Excecoes;
using PacPay.Dominio.Excecoes.Mensagens;
using PacPay.Dominio.Interfaces;
using PacPay.Infra.Contexto;

namespace PacPay.Infra.Repositorio
{
    public class RepositorioOperacao<T>(AppDbContexto contexto) : IRepositorioOperacao where T : Operacao
    {
        protected readonly AppDbContexto Contexto = contexto;

        public void Deposito(Operacao deposito, CancellationToken cancellationToken)
        {
            try
            {
                Contexto.Add(deposito);
            }
            catch (Exception ex)
            {
                throw new RepositorioExcecao($"{RepositorioErr.Cadastro}:  {ex.Message}");
            }
        }
    }
}
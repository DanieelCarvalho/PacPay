using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;

namespace PacPay.Infra.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : EntidadeBase
    {
        public void Adicionar(T entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(T entidade)
        {
            throw new NotImplementedException();
        }

        public Task<T?> BuscarComId(Guid numeroConta, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Excluir(T entidade)
        {
            throw new NotImplementedException();
        }
    }
}
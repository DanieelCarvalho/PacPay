using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Infra.Contexto;
using System;

namespace PacPay.Infra.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : EntidadeBase
    {
        protected readonly AppDbContexto Contexto;

        public RepositorioBase(AppDbContexto contexto)
        {
            Contexto = contexto;
        }

        public void Adicionar(T entidade)
        {
            entidade.DataCriacao = DateTime.Now.ToUniversalTime();

            Contexto.Add(entidade.Endereco);
            Contexto.Add(entidade);
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
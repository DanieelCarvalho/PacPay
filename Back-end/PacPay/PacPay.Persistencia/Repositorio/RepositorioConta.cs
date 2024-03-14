using Microsoft.EntityFrameworkCore;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Infra.Contexto;

namespace PacPay.Infra.Repositorio
{
    public class RepositorioConta<T> : IRepositorioConta where T : Conta
    {
        protected readonly AppDbContexto Contexto;

        public RepositorioConta(AppDbContexto contexto)
        {
            Contexto = contexto;
        }

        public async Task<bool> ContaExiste(string cpf, CancellationToken cancellationToken)
        {
            bool existe = await Contexto.Contas.AnyAsync(c => c.Cliente.Cpf == cpf, cancellationToken);

            return existe;
        }

        public async Task<Conta> BuscarConta(string cpf, CancellationToken cancellationToken)
        {
            Cliente? cliente = await Contexto.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf, cancellationToken) ?? throw new Exception("Conta não existe!");
            Conta? conta = await Contexto.Contas.FirstOrDefaultAsync(c => c.ClienteId == cliente.Id, cancellationToken) ?? throw new Exception("Conta não existe!");
            return conta;
        }

        public void Adicionar(Conta entidade)
        {
            try
            {
                entidade.DataCriacao = DateTime.Now.ToUniversalTime();

                Contexto.Add(entidade.Cliente.Endereco);
                Contexto.Add(entidade.Cliente);
                Contexto.Add(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Atualizar(Conta entidade)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Conta entidade)
        {
            throw new NotImplementedException();
        }
    }
}
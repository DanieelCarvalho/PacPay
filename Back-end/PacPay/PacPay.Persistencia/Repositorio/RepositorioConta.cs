using Microsoft.EntityFrameworkCore;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Excecoes;
using PacPay.Dominio.Excecoes.Mensagens;
using PacPay.Dominio.Interfaces;
using PacPay.Infra.Contexto;

namespace PacPay.Infra.Repositorio
{
    public sealed class RepositorioConta<T> : IRepositorioConta where T : Conta
    {
        private readonly AppDbContexto Contexto;

        public RepositorioConta(AppDbContexto contexto)
        {
            Contexto = contexto;
        }

        public async void Adicionar(Conta entidade, CancellationToken cancellationToken)
        {
            try
            {
                if (await ContaExiste(entidade.Cliente.Cpf, cancellationToken)) throw new RepositorioExcecao(ContaErr.ContaJaExiste);

                Contexto.Add(entidade.Cliente.Endereco);
                Contexto.Add(entidade.Cliente);
                Contexto.Add(entidade);
            }
            catch (Exception ex)
            {
                throw new RepositorioExcecao($"{RepositorioErr.Cadastro}:  {ex.Message}");
            }
        }

        public void Atualizar(Conta entidade)
        {
            try { Contexto.Update(entidade); }
            catch (Exception ex)
            {
                throw new RepositorioExcecao($"{RepositorioErr.Atualizacao}:  {ex.Message}");
            }
        }

        public void Excluir(Conta entidade)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ContaExiste(string cpf, CancellationToken cancellationToken)
        {
            bool existe = await Contexto.Contas.AnyAsync(c => c.Cliente.Cpf == cpf, cancellationToken);

            return existe;
        }

        public async Task<Conta> BuscarConta(string cpf, CancellationToken cancellationToken)
        {
            Cliente? cliente = await Contexto.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf, cancellationToken) ?? throw new RepositorioExcecao(ContaErr.ContaNaoEncontrada);
            Conta? conta = await Contexto.Contas.FirstOrDefaultAsync(c => c.ClienteId == cliente.Id, cancellationToken) ?? throw new RepositorioExcecao(ContaErr.ContaNaoEncontrada);
            return conta;
        }

        public async Task<Conta> BuscarConta(Guid id, CancellationToken cancellationToken)
        {
            Conta? conta = await Contexto.Contas.FirstOrDefaultAsync(c => c.Id == id, cancellationToken) ?? throw new RepositorioExcecao(ContaErr.ContaNaoEncontrada);
            return conta;
        }
    }
}
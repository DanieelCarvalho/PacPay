using Microsoft.EntityFrameworkCore;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Excecoes;
using PacPay.Dominio.Excecoes.Mensagens;
using PacPay.Dominio.Interfaces;
using PacPay.Infra.Contexto;

namespace PacPay.Infra.Repositorio
{
    public sealed class RepositorioConta<T>(AppDbContexto contexto) : IRepositorioConta where T : Conta
    {
        private readonly AppDbContexto Contexto = contexto;

        public async void Adicionar(Conta entidade, CancellationToken cancellationToken)
        {
            try
            {
                if (await ContaExiste(entidade.Cliente.Cpf, cancellationToken)) throw new RepositorioExcecao(ContaErr.ContaJaExiste);

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

        public void Desativar(Conta entidade)
        {
            try
            {
                Atualizar(entidade);
            }
            catch (Exception ex)
            {
                throw new RepositorioExcecao($"{RepositorioErr.Exclusao}:  {ex.Message}");
            }
        }

        public void Reativar(Conta entidade)
        {
            try
            {
                Atualizar(entidade);
            }
            catch (Exception ex)
            {
                throw new RepositorioExcecao($"{RepositorioErr.Atualizacao}:  {ex.Message}");
            }
        }

        public async Task<bool> ContaExiste(string cpf, CancellationToken cancellationToken)
        {
            try
            {
                bool existe = await Contexto.Contas.AnyAsync(c => c.Cliente.Cpf == cpf, cancellationToken);

                return existe;
            }
            catch (Exception ex)
            {
                throw new RepositorioExcecao($"{RepositorioErr.Cadastro}:  {ex.Message}");
            }
        }

        public async Task<Conta> BuscarConta(string cpf, CancellationToken cancellationToken)
        {
            try
            {
                Conta conta = await Contexto.Contas
                    .Include(c => c.Cliente)
                    .ThenInclude(c => c.Endereco)
                    .FirstOrDefaultAsync(c => c.Cliente.Cpf == cpf, cancellationToken) ?? throw new RepositorioExcecao(ContaErr.ContaNaoEncontrada);

                return conta;
            }
            catch (Exception ex)
            {
                throw new RepositorioExcecao($"{RepositorioErr.Cadastro}:  {ex.Message}");
            }
        }

        public async Task<Conta> BuscarConta(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Conta conta = await Contexto.Contas
                    .Include(c => c.Cliente)
                    .ThenInclude(c => c.Endereco)
                    .FirstOrDefaultAsync(c => c.Id == id, cancellationToken) ?? throw new RepositorioExcecao(ContaErr.ContaNaoEncontrada);

                return conta;
            }
            catch (Exception ex)
            {
                throw new RepositorioExcecao($"{RepositorioErr.Cadastro}:  {ex.Message}");
            }
        }

        public async Task<Conta?> BuscarCliente(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Conta? conta = await Contexto.Contas
                        .Include(c => c.Cliente)
                        .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

                return conta;
            }
            catch (Exception ex)
            {
                throw new RepositorioExcecao($"{RepositorioErr.Cadastro}:  {ex.Message}");
            }
        }

        public async Task<string?> PegarCpf(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                Conta? conta = await Contexto.Contas
                         .Include(c => c.Cliente)
                         .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

                if (conta == null) return null;

                return conta.Cliente.Cpf;
            }
            catch (Exception ex)
            {
                throw new RepositorioExcecao($"{RepositorioErr.Cadastro}:  {ex.Message}");
            }
        }
    }
}
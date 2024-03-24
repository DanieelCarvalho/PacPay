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

        public void Adicionar(Conta entidade, CancellationToken cancellationToken)
        {
            Contexto.Add(entidade);
        }

        public void Atualizar(Conta entidade)
        {
            Contexto.Update(entidade);
        }

        public void Desativar(Conta entidade)
        {
            Atualizar(entidade);
        }

        public void Reativar(Conta entidade)
        {
            Atualizar(entidade);
        }

        public async Task<bool> ContaExiste(string cpf, CancellationToken cancellationToken)
        {
            bool existe = await Contexto.Contas.AnyAsync(c => c.Cliente.Cpf == cpf, cancellationToken);

            return existe;
        }

        public async Task<Conta?> BuscarConta(string cpf, CancellationToken cancellationToken)
        {
            Conta? conta = await Contexto.Contas
                .Include(c => c.Cliente)
                .ThenInclude(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Cliente.Cpf == cpf, cancellationToken);

            return conta;
        }

        public async Task<Conta?> BuscarConta(Guid id, CancellationToken cancellationToken)
        {
            Conta? conta = await Contexto.Contas
                .Include(c => c.Cliente)
                .ThenInclude(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            return conta;
        }

        public async Task<Conta?> BuscarCliente(Guid id, CancellationToken cancellationToken)
        {
            Conta? conta = await Contexto.Contas
                    .Include(c => c.Cliente)
                    .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            return conta;
        }

        public async Task<string?> PegarCpf(Guid id, CancellationToken cancellationToken)
        {
            Conta? conta = await Contexto.Contas
                     .Include(c => c.Cliente)
                     .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (conta == null) return null;

            return conta.Cliente.Cpf;
        }
    }
}
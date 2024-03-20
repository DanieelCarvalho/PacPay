using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.Dominio.Entidades
{
    public class Conta
    {
        public Guid Id { get; set; }

        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public decimal Saldo { get; set; }
        public bool Admin { get; set; } = false;
        public DateTime DataCriacao { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }
        public DateTime? DataExclusao { get; set; }

        public async Task RegistrarConta(IEncriptador encriptador, IRepositorioConta repositorioConta, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            Senha = encriptador.Encriptar(Senha);
            Saldo = 1000;
            DataCriacao = DateTime.Now.ToUniversalTime();

            await repositorioConta.Adicionar(this, cancellationToken);

            await commitDados.Commit(cancellationToken);
        }

        public void AtualizarConta(IRepositorioConta repositorioConta, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            UltimaAtualizacao = DateTime.Now.ToUniversalTime();
            repositorioConta.Atualizar(this);
            commitDados.Commit(cancellationToken);
        }

        public void AtualizarConta(IRepositorioConta repositorioConta)
        {
            repositorioConta.Atualizar(this);
        }
    }
}
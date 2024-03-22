using PacPay.Dominio.Excecoes;
using PacPay.Dominio.Excecoes.Mensagens;
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
        public bool Ativa { get; set; } = true;
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
            if (Ativa == false) throw new DominioExcecao(ContaErr.ContaDesativada);
            UltimaAtualizacao = DateTime.Now.ToUniversalTime();

            repositorioConta.Atualizar(this);
            commitDados.Commit(cancellationToken);
        }

        public void AtualizarConta(IRepositorioConta repositorioConta)
        {
            if (Ativa == false) throw new DominioExcecao(ContaErr.ContaDesativada);
            UltimaAtualizacao = DateTime.Now.ToUniversalTime();

            repositorioConta.Atualizar(this);
        }

        public void Desativar(string senha, IRepositorioConta repositorioConta, IEncriptador encriptador, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            if (encriptador.Comparar(senha, Senha) == false) throw new DominioExcecao(ContaErr.SenhaInvalida);
            if (Saldo > 0) throw new DominioExcecao(ContaErr.DesativacaoInvalida);

            Ativa = false;
            DataExclusao = DateTime.Now.ToUniversalTime();

            repositorioConta.Desativar(this);
            commitDados.Commit(cancellationToken);
        }

        public void Reativar(string cpf, string email, string senha, IRepositorioConta repositorioConta, IEncriptador encriptador, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            if (Ativa) throw new DominioExcecao(ContaErr.ContaAtiva);
            if (Cliente.Cpf != cpf || Cliente.Email != email) throw new DominioExcecao(ContaErr.ReativacaoInvalida);
            if (encriptador.Comparar(senha, Senha) == false) throw new DominioExcecao(ContaErr.SenhaInvalida);

            Ativa = true;
            DataExclusao = null;
            UltimaAtualizacao = DateTime.Now.ToUniversalTime();

            repositorioConta.Reativar(this);
            commitDados.Commit(cancellationToken);
        }
    }
}
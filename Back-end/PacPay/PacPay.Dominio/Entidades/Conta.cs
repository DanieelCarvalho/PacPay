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

        public async Task Registrar(IEncriptador encriptador, IRepositorioConta repositorioConta, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            Senha = encriptador.Encriptar(Senha);
            Saldo = 1000;
            DataCriacao = DateTime.Now.ToUniversalTime();

            if (await repositorioConta.ContaExiste(Cliente.Cpf, cancellationToken)) throw ContaErr.ContaJaExiste403;
            repositorioConta.Adicionar(this, cancellationToken);

            await commitDados.Commit(cancellationToken);
        }

        public string Login(string senha, IEncriptador encriptador, IAutenticador autenticador)
        {
            if (Ativa == false) throw ContaErr.ContaDesativada403;
            bool autenticado = encriptador.Comparar(senha, Senha);

            if (!autenticado) throw ContaErr.SenhaInvalida401;

            return autenticador.GerarToken(Id);
        }

        public void Atualizar(IRepositorioConta repositorioConta)
        {
            if (Ativa == false) throw ContaErr.ContaDesativada403;
            UltimaAtualizacao = DateTime.Now.ToUniversalTime();

            repositorioConta.Atualizar(this);
        }

        public void Atualizar(string? senha, IRepositorioConta repositorioConta, IEncriptador encriptador, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            if (Ativa == false) throw ContaErr.ContaDesativada403;
            if (senha != null) Senha = encriptador.Encriptar(senha);
            UltimaAtualizacao = DateTime.Now.ToUniversalTime();

            repositorioConta.Atualizar(this);
            commitDados.Commit(cancellationToken);
        }

        public static async void AtualizarValidador(string? cpf, IRepositorioConta repositorioConta, CancellationToken cancellationToken)
        {
            if (cpf != null && await repositorioConta.ContaExiste(cpf, cancellationToken)) throw ContaErr.ContaJaExiste403;
        }

        public void Desativar(string senha, IRepositorioConta repositorioConta, IEncriptador encriptador, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            if (encriptador.Comparar(senha, Senha) == false) throw ContaErr.SenhaInvalida401;
            if (Saldo > 0) throw ContaErr.DesativacaoInvalida403;
            if (!Ativa) throw ContaErr.ContaDesativada403;

            Ativa = false;
            DataExclusao = DateTime.Now.ToUniversalTime();

            repositorioConta.Desativar(this);
            commitDados.Commit(cancellationToken);
        }

        public void Reativar(string cpf, string email, string senha, IRepositorioConta repositorioConta, IEncriptador encriptador, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            if (Ativa) throw ContaErr.ContaAtiva403;
            if (Cliente.Cpf != cpf || Cliente.Email != email) throw ContaErr.ReativacaoInvalida404;
            if (encriptador.Comparar(senha, Senha) == false) throw ContaErr.SenhaInvalida401;

            Ativa = true;
            DataExclusao = null;
            UltimaAtualizacao = DateTime.Now.ToUniversalTime();

            repositorioConta.Reativar(this);
            commitDados.Commit(cancellationToken);
        }
    }
}
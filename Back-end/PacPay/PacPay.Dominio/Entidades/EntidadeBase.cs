namespace PacPay.Dominio.Entidades
{
    public abstract class EntidadeBase(string nome, string documento, string email, string senha, string dataNascimento, Endereco endereco)
    {
        public Guid NumeroConta { get; private set; } = Guid.NewGuid();

        public string Nome { get; private set; } = nome;

        public string Documento { get; private set; } = documento;
        public string Email { get; private set; } = email;
        public string Senha { get; private set; } = senha;

        public string DataNascimento { get; private set; } = dataNascimento;
        public Decimal Saldo { get; private set; }

        public Endereco Endereco { get; private set; } = endereco;
        public DateTimeOffset DataCriacao { get; private set; } = DateTimeOffset.Now;
        public DateTimeOffset? UltimaAtualizacao { get; private set; }
        public DateTimeOffset? DataExclusao { get; private set; }

        public abstract void AtualizarNome(string nome);

        public abstract void AtualizarDocumento(string documento);

        public abstract void AtualizarEmail(string email);

        public abstract void AtualizarSenha(string senha);

        public abstract void Deposito(Deposito deposito);

        public abstract void Saque(Saque saque);

        public abstract void Transferencia(Transferencia transferencia);

        public abstract void AualizarEndereco(Endereco endereco);

        public abstract void AtualizarConta(string Nome, string email, string senha, string dataDeNascimento, Endereco endereco);

        public abstract void ExcluirConta(Guid numeroConta, string cof, string senha);
    }
}
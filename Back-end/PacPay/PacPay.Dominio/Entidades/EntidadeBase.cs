namespace PacPay.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        public Guid NumeroConta { get; set; }
        public string Nome { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string DataNascimento { get; set; } = null!;
        public decimal Saldo { get; set; } = 0;
        public Guid EnderecoId { get; set; }
        public Endereco Endereco { get; set; } = null!;

        public DateTime DataCriacao { get; set; } = DateTime.Now.ToUniversalTime();

        public DateTime? UltimaAtualizacao { get; set; }
        public DateTime? DataExclusao { get; set; }

        public abstract void AtualizarNome(string nome);

        public abstract void AtualizarDocumento(string documento);

        public abstract void AtualizarEmail(string email);

        public abstract void AtualizarSenha(string senha);

        public abstract void Deposito(Deposito deposito);

        public abstract void Saque(Saque saque);

        public abstract void Transferencia(Transferencia transferencia);

        public abstract void AualizarEndereco(Endereco endereco);

        public abstract void AtualizarConta(string Nome, string email, string senha, string dataDeNascimento, Endereco endereco);

        public abstract void ExcluirConta(Guid numeroConta, string documento, string senha);
    }
}
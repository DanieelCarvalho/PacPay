namespace PacPay.Dominio.Entidades
{
    public class Cliente(string nome, string documento, string email, string senha, string dataNascimento, Endereco endereco) : EntidadeBase(nome, documento, email, senha, dataNascimento, endereco)
    {
        public override void AtualizarConta(string Nome, string email, string senha, string dataDeNascimento, Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public override void AtualizarDocumento(string documento)
        {
            throw new NotImplementedException();
        }

        public override void AtualizarEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override void AtualizarNome(string nome)
        {
            throw new NotImplementedException();
        }

        public override void AtualizarSenha(string senha)
        {
            throw new NotImplementedException();
        }

        public override void AualizarEndereco(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public override void Deposito(Deposito deposito)
        {
            throw new NotImplementedException();
        }

        public override void ExcluirConta(Guid numeroConta, string cof, string senha)
        {
            throw new NotImplementedException();
        }

        public override void Saque(Saque saque)
        {
            throw new NotImplementedException();
        }

        public override void Transferencia(Transferencia transferencia)
        {
            throw new NotImplementedException();
        }
    }
}
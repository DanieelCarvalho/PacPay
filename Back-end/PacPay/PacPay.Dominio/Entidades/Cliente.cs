namespace PacPay.Dominio.Entidades
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; set; } = null!;
        public string Documento { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string DataNascimento { get; set; } = null!;
        public Guid EnderecoId { get; private set; }
        public Endereco Endereco { get; set; } = null!;
    }
}
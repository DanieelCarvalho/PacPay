namespace PacPay.Dominio.Entidades
{
    public class Endereco
    {
        public Guid Id { get; private set; }
        public string Cep { get; set; } = null!;
        public string Rua { get; set; } = null!;
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string Cidade { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string? PontoDeReferencia { get; set; }
    }
}
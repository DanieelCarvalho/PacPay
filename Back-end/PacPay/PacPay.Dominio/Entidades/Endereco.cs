namespace PacPay.Dominio.Entidades
{
    public class Endereco(string cep, string rua, string? numero, string? complemento, string? bairro, string cidade, string estado)
    {
        public string Cep { get; private set; } = cep;
        public string Rua { get; private set; } = rua;
        public string? Numero { get; private set; } = numero;
        public string? Complemento { get; private set; } = complemento;
        public string? Bairro { get; private set; } = bairro;
        public string Cidade { get; private set; } = cidade;
        public string Estado { get; private set; } = estado;
    }
}
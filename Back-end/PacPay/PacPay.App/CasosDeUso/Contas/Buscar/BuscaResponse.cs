namespace PacPay.App.CasosDeUso.Contas.Buscar
{
    public sealed record BuscaResponse
    {
        public string Nome { get; set; } = null!;
        public string Cpf { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal Saldo { get; set; }
        public string DataDeCriacao { get; set; } = null!;
    }
}
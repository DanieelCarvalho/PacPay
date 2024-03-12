namespace PacPay.App.CasosDeUso.AdicionarConta
{
    public sealed record LoginResponse
    {
        public string Nome { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
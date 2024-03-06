namespace PacPay.App.CasosDeUso.AdicionarConta
{
    public sealed record LoginResponse
    {
        public string Token { get; set; } = null!;
    }
}
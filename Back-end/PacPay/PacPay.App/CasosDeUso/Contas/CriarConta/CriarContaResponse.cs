namespace PacPay.App.CasosDeUso.Contas.CriarConta
{
    public sealed record CriarContaResponse
    {
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
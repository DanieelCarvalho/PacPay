namespace PacPay.App.CasosDeUso.AdicionarCliente
{
    public sealed record AdicionarClienteResponse
    {

        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;

    }
}
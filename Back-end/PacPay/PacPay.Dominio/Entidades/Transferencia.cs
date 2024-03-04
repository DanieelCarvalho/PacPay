namespace PacPay.Dominio.Entidades
{
    public class Transferencia(decimal valor, Guid contaOrigem, Guid contaDestino)
    {
        public decimal Valor { get; private set; } = valor;

        public Guid ContaOrigem { get; private set; } = contaOrigem;

        public Guid ContaDestino { get; private set; } = contaDestino;
        public DateTimeOffset DataTransferencia { get; private set; } = DateTimeOffset.Now;
    }
}
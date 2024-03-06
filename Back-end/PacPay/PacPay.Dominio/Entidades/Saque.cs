namespace PacPay.Dominio.Entidades
{
    public class Saque
    {
        public Guid Id { get; private set; }
        public decimal Valor { get; set; }

        public Guid IdContaOrigem { get; set; }
        public DateTimeOffset DataSaque { get; private set; } = DateTimeOffset.Now.ToUniversalTime();
    }
}
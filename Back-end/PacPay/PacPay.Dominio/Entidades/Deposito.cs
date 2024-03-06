namespace PacPay.Dominio.Entidades
{
    public class Deposito
    {
        public Guid Id { get; private set; }
        public decimal Valor { get; set; }
        public Guid IdContaOrigem { get; set; }
        public DateTimeOffset DataDeposito { get; private set; } = DateTimeOffset.Now.ToUniversalTime();
    }
}
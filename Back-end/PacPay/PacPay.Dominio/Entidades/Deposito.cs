namespace PacPay.Dominio.Entidades
{
    public class Deposito
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public decimal Valor { get;  set; }
        public Guid ContaOrigem { get;  set; } 
        public DateTimeOffset DataDeposito { get; private set; } = DateTimeOffset.Now.ToUniversalTime();
    }
}
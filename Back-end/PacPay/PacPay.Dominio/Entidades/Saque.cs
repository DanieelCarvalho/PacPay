namespace PacPay.Dominio.Entidades
{
    public class Saque
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public decimal Valor { get;  set; }

        public Guid ContaOrigem { get;  set; } 
        public DateTimeOffset DataSaque { get; private set; } = DateTimeOffset.Now.ToUniversalTime();
    }
}
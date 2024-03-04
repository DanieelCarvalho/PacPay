namespace PacPay.Dominio.Entidades
{
    public class Transferencia
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public decimal Valor { get;  set; } 

        public Guid ContaOrigem { get;  set; }

        public Guid ContaDestino { get;  set; } 
        public DateTimeOffset DataTransferencia { get; private set; } = DateTimeOffset.Now.ToUniversalTime();
    }
}
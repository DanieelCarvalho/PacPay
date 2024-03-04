namespace PacPay.Dominio.Entidades
{
    public class Saque(decimal valor)
    {
        public decimal Valor { get; private set; } = valor;
        public DateTimeOffset DataSaque { get; private set; } = DateTimeOffset.Now;
    }
}
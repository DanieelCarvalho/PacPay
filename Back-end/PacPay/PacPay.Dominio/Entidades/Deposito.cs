namespace PacPay.Dominio.Entidades
{
    public class Deposito(decimal valor)
    {
        public decimal Valor { get; private set; } = valor;

        public DateTimeOffset DataDeposito { get; private set; } = DateTimeOffset.Now;
    }
}
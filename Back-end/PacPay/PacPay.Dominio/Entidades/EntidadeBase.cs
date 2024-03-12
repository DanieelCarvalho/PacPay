namespace PacPay.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        public Guid Id { get; set; }

        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public decimal Saldo { get; set; } = 1000;

        public bool Admin { get; set; }
        public DateTime DataCriacao { get; set; }

        public DateTime? UltimaAtualizacao { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
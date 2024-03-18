namespace PacPay.App.CasosDeUso.Operacoes.Historico
{
    public sealed record HistoricoResponse
    {
        public decimal Valor { get; set; }
        public string TipoOperacao { get; set; } = null!;
        public string? CpfDestino { get; set; }
        public string DataOperacao { get; set; } = null!;
        public string? Descricao { get; set; }
    }
}
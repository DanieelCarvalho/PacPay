namespace PacPay.Dominio.Excecoes.Mensagens
{
    public static class OperacoesErr
    {
        public const string OperacaoNaoEncontrada = "Operação não encontrada";
        public const string ValorInvalido = "Valor inválido";
        public const string SaldoInsuficiente = "Saldo insuficiente";
        public const string TransferenciaMesmaConta = "Transferência para a mesma conta";
        public const string ContaDestinoNaoEncontrada = "Conta destino não encontrada";
        public const string HistoricoVazio = "Não há transações para mostrar";
    }
}
namespace PacPay.Dominio.Excecoes.Mensagens
{
    public static class OperacoesErr
    {
        public static readonly Erro OperacaoNaoEncontrada404 = new("Operação não encontrada", 404);
        public static readonly Erro ValorInvalido400 = new("Valor inválido", 400);
        public static readonly Erro SaldoInsuficiente402 = new("Saldo insuficiente", 402);
        public static readonly Erro TransferenciaMesmaConta403 = new("Transferência para a mesma conta", 403);
        public static readonly Erro ContaDestinoNaoEncontrada404 = new("Conta destino não encontrada", 404);
        public static readonly Erro HistoricoVazio204 = new("Não há transações para mostrar", 204);
        public static readonly Erro Desconhecido500 = new("Erro desconhecido", 500);
    }
}
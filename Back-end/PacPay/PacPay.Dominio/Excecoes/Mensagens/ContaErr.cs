namespace PacPay.Dominio.Excecoes.Mensagens
{
    public static class ContaErr
    {
        public const string ContaNaoEncontrada = "Conta não encontrada";
        public const string ContaJaExiste = "Conta já existe";
        public const string SaldoInsuficiente = "Saldo insuficiente";
        public const string ContaDestinoNaoEncontrada = "Conta destino não encontrada";
        public const string ContaDesativada = "Conta desativada";
        public const string SenhaInvalida = "Senha inválida";
        public const string DesativacaoInvalida = "A conta ainda possui saldo, faça um saque ou transferência para zerar a conta";
        public const string ContaAtiva = "A conta já está ativa";
        public const string ReativacaoInvalida = "Cpf e Email não correspondem a nenhuma conta cadastrada";
    }
}
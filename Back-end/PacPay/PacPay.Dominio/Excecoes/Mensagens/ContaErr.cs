namespace PacPay.Dominio.Excecoes.Mensagens
{
    public static class ContaErr
    {
        public static readonly Erro ContaNaoEncontrada404 = new("Conta não encontrada", 404);
        public static readonly Erro ContaJaExiste403 = new("Conta já existe", 409);
        public static readonly Erro SaldoInsuficiente406 = new("Saldo insuficiente", 406);
        public static readonly Erro ContaDesativada403 = new("A conta está desativada", 403);
        public static readonly Erro ContaDestinoDesativada403 = new("A conta destino está desativada", 403);
        public static readonly Erro SenhaInvalida401 = new("Senha inválida", 401);
        public static readonly Erro DesativacaoInvalida403 = new("A conta ainda possui saldo, faça um saque ou transferência para zerar a conta", 403);
        public static readonly Erro ContaAtiva403 = new("A conta já está ativa", 409);
        public static readonly Erro ReativacaoInvalida404 = new("Cpf e Email não correspondem a nenhuma conta cadastrada", 404);
        public static readonly Erro Desconhecido500 = new("Erro desconhecido", 500);
    }
}
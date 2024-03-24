using PacPay.Dominio.Entidades.Enums;
using PacPay.Dominio.Excecoes.Mensagens;
using PacPay.Dominio.Interfaces;

namespace PacPay.Dominio.Entidades
{
    public class Operacao
    {
        public Guid Id { get; private set; }
        public decimal Valor { get; set; }
        public Transacoes TipoOperacao { get; set; }
        public Guid IdContaOrigem { get; set; }
        public Guid IdContaDestino { get; set; }
        public DateTime DataOperacao { get; set; }
        public string? Descricao { get; set; }

        private void InfoOperacao(decimal valor, Transacoes tipoOperacao, Guid idContaOrigem, Guid idContaDestino, string? descricao)
        {
            Valor = valor;
            TipoOperacao = tipoOperacao;
            IdContaOrigem = idContaOrigem;
            IdContaDestino = idContaDestino;
            DataOperacao = DateTime.Now.ToUniversalTime();
            Descricao = descricao ?? string.Empty;
        }

        private static void OperacaoConta(decimal valor, Conta conta, Transacoes tipoOperacao, IRepositorioConta repositorioConta)
        {
            if (tipoOperacao == Transacoes.Saque) conta.Saldo -= valor;
            if (tipoOperacao == Transacoes.Deposito) conta.Saldo += valor;

            conta.Atualizar(repositorioConta);
        }

        public void Deposito(decimal valor, string? descricao, Conta conta, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            if(conta.Ativa == false) throw ContaErr.ContaDesativada403;
            if (valor <= 0) throw OperacoesErr.ValorInvalido400;

            InfoOperacao(valor, Transacoes.Deposito, conta.Id, conta.Id, descricao);

            OperacaoConta(valor, conta, Transacoes.Deposito, repositorioConta);

            repositorioOperacao.Transacao(this);

            commitDados.Commit(cancellationToken);
        }

        public void Saque(decimal valor, string? descricao, Conta conta, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            if(conta.Ativa == false) throw ContaErr.ContaDesativada403;
            if (valor <= 0) throw OperacoesErr.ValorInvalido400;
            if (valor > conta.Saldo) throw OperacoesErr.SaldoInsuficiente402;

            InfoOperacao(valor, Transacoes.Saque, conta.Id, conta.Id, descricao);

            OperacaoConta(valor, conta, Transacoes.Saque, repositorioConta);

            repositorioOperacao.Transacao(this);
            commitDados.Commit(cancellationToken);
        }

        public void Transferencia(decimal valor, string? descricao, Conta contaOrigem, Conta contaDestino, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            if(contaOrigem.Ativa == false) throw ContaErr.ContaDesativada403;
            if(contaDestino.Ativa == false) throw ContaErr.ContaDestinoDesativada403;
            if (valor <= 0) throw OperacoesErr.ValorInvalido400;
            if (valor > contaOrigem.Saldo) throw OperacoesErr.SaldoInsuficiente402;
            if (contaOrigem.Id == contaDestino.Id) throw OperacoesErr.TransferenciaMesmaConta403;

            InfoOperacao(valor, Transacoes.Transferencia, contaOrigem.Id, contaDestino.Id, descricao);

            OperacaoConta(valor, contaOrigem, Transacoes.Saque, repositorioConta);
            OperacaoConta(valor, contaDestino, Transacoes.Deposito, repositorioConta);

            repositorioOperacao.Transacao(this);
            commitDados.Commit(cancellationToken);
        }

        public static List<Operacao> Historico(Guid id, int numeroDaPagina, IRepositorioOperacao repositorioOperacao, CancellationToken cancellationToken)
        {
            List<Operacao> operacoes = repositorioOperacao.Historico(id, numeroDaPagina, cancellationToken);
            Console.WriteLine("aqui");
            if (operacoes.Count == 0) throw OperacoesErr.HistoricoVazio204;
            Console.WriteLine("depois");
            return operacoes;
        }
    }
}
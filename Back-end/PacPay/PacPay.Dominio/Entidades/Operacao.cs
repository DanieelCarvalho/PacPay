using PacPay.Dominio.Entidades.Enums;
using PacPay.Dominio.Excecoes;
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

        private void OperacaoConta(decimal valor, Conta conta, Transacoes tipoOperacao, IRepositorioConta repositorioConta)
        {
            if (tipoOperacao == Transacoes.Saque) conta.Saldo -= valor;
            if (tipoOperacao == Transacoes.Deposito) conta.Saldo += valor;

            conta.UltimaAtualizacao = DateTime.Now.ToUniversalTime();
            conta.AtualizarConta(repositorioConta);
        }

        public void Deposito(decimal valor, string? descricao, Conta conta, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            if (valor <= 0) throw new DominioExcecao(OperacoesErr.ValorInvalido);

            InfoOperacao(valor, Transacoes.Deposito, conta.Id, conta.Id, descricao);

            OperacaoConta(valor, conta, Transacoes.Deposito, repositorioConta);

            repositorioOperacao.Transacao(this);

            commitDados.Commit(cancellationToken);
        }

        public void Saque(decimal valor, string? descricao, Conta conta, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            if (valor <= 0) throw new DominioExcecao(OperacoesErr.ValorInvalido);
            if (valor > conta.Saldo) throw new DominioExcecao(OperacoesErr.SaldoInsuficiente);

            InfoOperacao(valor, Transacoes.Saque, conta.Id, conta.Id, descricao);

            OperacaoConta(valor, conta, Transacoes.Saque, repositorioConta);

            repositorioOperacao.Transacao(this);
            commitDados.Commit(cancellationToken);
        }

        public void Transferencia(decimal valor, string? descricao, Conta contaOrigem, Conta contaDestino, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            if (valor <= 0) throw new DominioExcecao(OperacoesErr.ValorInvalido);
            if (valor > contaOrigem.Saldo) throw new DominioExcecao(OperacoesErr.SaldoInsuficiente);
            if (contaOrigem.Id == contaDestino.Id) throw new DominioExcecao(OperacoesErr.TransferenciaMesmaConta);

            InfoOperacao(valor, Transacoes.Transferencia, contaOrigem.Id, contaDestino.Id, descricao);

            OperacaoConta(valor, contaOrigem, Transacoes.Saque, repositorioConta);
            OperacaoConta(valor, contaDestino, Transacoes.Deposito, repositorioConta);

            repositorioOperacao.Transacao(this);
            commitDados.Commit(cancellationToken);
        }
    }
}
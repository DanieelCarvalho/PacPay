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

        public void Deposito(decimal valor, Conta conta, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            if (valor <= 0) throw new DominioExcecao(OperacoesErr.ValorInvalido);

            Valor = valor;
            TipoOperacao = Transacoes.Deposito;
            IdContaOrigem = conta.Id;
            IdContaDestino = conta.Id;
            DataOperacao = DateTime.Now.ToUniversalTime();

            conta.Saldo += valor;
            conta.UltimaAtualizacao = DateTime.Now.ToUniversalTime();
            conta.AtualizarConta(repositorioConta);

            repositorioOperacao.Transacao(this);

            commitDados.Commit(cancellationToken);
        }

        public void Saque(decimal valor, Conta conta, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            if (valor <= 0) throw new DominioExcecao(OperacoesErr.ValorInvalido);
            if (valor > conta.Saldo) throw new DominioExcecao(OperacoesErr.SaldoInsuficiente);

            Valor = valor;
            TipoOperacao = Transacoes.Saque;
            IdContaOrigem = conta.Id;
            IdContaDestino = conta.Id;
            DataOperacao = DateTime.Now.ToUniversalTime();

            conta.Saldo -= valor;
            conta.UltimaAtualizacao = DateTime.Now.ToUniversalTime();
            conta.AtualizarConta(repositorioConta);

            repositorioOperacao.Transacao(this);
            commitDados.Commit(cancellationToken);
        }

        public void Transferencia(decimal valor, Conta contaOrigem, Conta contaDestino, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados, CancellationToken cancellationToken)
        {
            if (valor <= 0) throw new DominioExcecao(OperacoesErr.ValorInvalido);
            if (valor > contaOrigem.Saldo) throw new DominioExcecao(OperacoesErr.SaldoInsuficiente);
            if (contaOrigem.Id == contaDestino.Id) throw new DominioExcecao(OperacoesErr.TransferenciaMesmaConta);

            Valor = valor;
            TipoOperacao = Transacoes.Transferencia;
            IdContaOrigem = contaOrigem.Id;
            IdContaDestino = contaDestino.Id;
            DataOperacao = DateTime.Now.ToUniversalTime();

            contaOrigem.Saldo -= valor;
            contaOrigem.UltimaAtualizacao = DateTime.Now.ToUniversalTime();
            contaOrigem.AtualizarConta(repositorioConta);

            contaDestino.Saldo += valor;
            contaDestino.UltimaAtualizacao = DateTime.Now.ToUniversalTime();
            contaDestino.AtualizarConta(repositorioConta);

            repositorioOperacao.Transacao(this);
            commitDados.Commit(cancellationToken);
        }
    }
}
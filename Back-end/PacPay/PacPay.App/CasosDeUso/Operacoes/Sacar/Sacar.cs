﻿using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Excecoes.Mensagens;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Operacoes.Sacar
{
    public sealed class Sacar(IAutenticador autenticador, IRepositorioConta repositorioConta, IRepositorioOperacao repositorioOperacao, ICommitDados commitDados) : IRequestHandler<SacarRequest>
    {
        private readonly IAutenticador _autenticador = autenticador;
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly IRepositorioOperacao _repositorioOperacao = repositorioOperacao;
        private readonly ICommitDados _commitDados = commitDados;

        public async Task Handle(SacarRequest request, CancellationToken cancellationToken)
        {
            FluentValidation.Results.ValidationResult resultado = new SacarValidador().Validate(request);
            if (!resultado.IsValid) throw new FluentValidation.ValidationException(resultado.Errors);

            Guid id = Guid.Parse(_autenticador.PegarId());
            decimal valor = request.Valor;
            string? descricao = request.Descricao;

            Conta conta = await _repositorioConta.BuscarConta(id, cancellationToken) ?? throw ContaErr.ContaNaoEncontrada404;

            new Operacao().Saque(valor, descricao, conta, _repositorioConta, _repositorioOperacao, _commitDados, cancellationToken);
        }
    }
}
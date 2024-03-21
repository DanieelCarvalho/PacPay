﻿using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.Contas.Desativar
{
    public sealed class Desativar(IRepositorioConta repositorioConta, ICommitDados commitDados, IAutenticador autenticador, IEncriptador encriptador) : IRequestHandler<DesativarRequest, DesativarResponse>
    {
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly ICommitDados _commitDados = commitDados;
        private readonly IAutenticador _autenticador = autenticador;
        private readonly IEncriptador _encriptador = encriptador;

        public async Task<DesativarResponse> Handle(DesativarRequest request, CancellationToken cancellationToken)
        {
            FluentValidation.Results.ValidationResult resultado = new DesativarValidador().Validate(request);
            if (!resultado.IsValid) throw new FluentValidation.ValidationException(resultado.Errors);

            Guid id = Guid.Parse(_autenticador.PegarId());
            Conta conta = await _repositorioConta.BuscarConta(id, cancellationToken);

            conta.Desativar(request.Senha, _repositorioConta, _encriptador, _commitDados, cancellationToken);

            return new DesativarResponse { Mensagem = "Conta desativada com sucesso!" };
        }
    }
}
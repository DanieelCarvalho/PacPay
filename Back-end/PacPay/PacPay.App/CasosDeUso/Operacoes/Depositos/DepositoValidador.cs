using FluentValidation;
using PacPay.App.CasosDeUso.Operacoes.Deposito;

namespace PacPay.App.CasosDeUso.Operacoes.Depositos
{
    public sealed class DepositoValidador : AbstractValidator<DepositoRequest>
    {
        public DepositoValidador()
        {
            RuleFor(x => x.Valor).GreaterThan(0).WithMessage("O valor do depósito deve ser maior que zero.");
        }
    }
}
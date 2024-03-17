using FluentValidation;

namespace PacPay.App.CasosDeUso.Operacoes.Depositos
{
    public sealed class DepositoValidador : AbstractValidator<DepositoRequest>
    {
        public DepositoValidador()
        {
            RuleFor(x => x.Valor).NotEmpty().GreaterThan(0).WithMessage("O valor do depósito deve ser maior que zero.");
        }
    }
}
using FluentValidation;

namespace PacPay.App.CasosDeUso.Operacoes.Depositar
{
    public sealed class DepositarValidador : AbstractValidator<DepositarRequest>
    {
        public DepositarValidador()
        {
            RuleFor(x => x.Valor).NotEmpty().GreaterThan(0).WithMessage("O valor do depósito deve ser maior que zero.");
            RuleFor(x => x.Descricao).MaximumLength(100).WithMessage("A descrição do depósito deve ter no máximo 100 caracteres.");
        }
    }
}
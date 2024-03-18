using FluentValidation;

namespace PacPay.App.CasosDeUso.Operacoes.Depositos
{
    public sealed class DepositoValidador : AbstractValidator<DepositoRequest>
    {
        public DepositoValidador()
        {
            RuleFor(x => x.Valor).NotEmpty().GreaterThan(0).WithMessage("O valor do depósito deve ser maior que zero.");
            RuleFor(x => x.Descricao).MaximumLength(100).WithMessage("A descrição do depósito deve ter no máximo 100 caracteres.");
        }
    }
}
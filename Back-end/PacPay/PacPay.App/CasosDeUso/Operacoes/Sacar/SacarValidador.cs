using FluentValidation;

namespace PacPay.App.CasosDeUso.Operacoes.Sacar
{
    public sealed class SacarValidador : AbstractValidator<SacarRequest>
    {
        public SacarValidador()
        {
            RuleFor(x => x.Valor).NotEmpty().GreaterThan(0).WithMessage("O valor do saque deve ser maior que zero.");
            RuleFor(x => x.Descricao).MaximumLength(100).WithMessage("A descrição do saque deve ter no máximo 100 caracteres.");
        }
    }
}
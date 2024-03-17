using FluentValidation;

namespace PacPay.App.CasosDeUso.AdicionarConta
{
    public sealed class LoginValidador : AbstractValidator<LoginRequest>
    {
        public LoginValidador()
        {
            RuleFor(x => x.Senha)
               .NotEmpty().MinimumLength(8).MaximumLength(100);

            RuleFor(x => x.Cpf)
                .NotEmpty().Matches(@"^\d{11}$|^\d{14}$").WithMessage("O CPF só pode conter números e deve ter exatamente 11 dígitos.");
        }
    }
}
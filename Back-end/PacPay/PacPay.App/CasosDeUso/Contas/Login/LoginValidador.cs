using FluentValidation;

namespace PacPay.App.CasosDeUso.AdicionarConta
{
    public sealed class AdicionarContaValidador : AbstractValidator<LoginRequest>
    {
        public AdicionarContaValidador()
        {
            RuleFor(x => x.Senha)
               .NotEmpty().MinimumLength(8).MaximumLength(100);

            RuleFor(x => x.Documento)
                .NotEmpty().Matches(@"^\d{11}$|^\d{14}$").WithMessage("O documento só pode conter números e deve ter exatamente 11 (CPF) ou 14 (CNPJ) dígitos.");
        }
    }
}
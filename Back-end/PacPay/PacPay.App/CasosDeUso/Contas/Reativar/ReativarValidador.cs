using FluentValidation;

namespace PacPay.App.CasosDeUso.Contas.Reativar
{
    public sealed class ReativarValidador : AbstractValidator<ReativarRequest>
    {
        public ReativarValidador()
        {
            RuleFor(x => x.Cpf)
               .NotEmpty().Matches(@"^\d{11}$|^\d{14}$").WithMessage("O CPF só pode conter números e deve ter exatamente 11 dígitos.");

            RuleFor(x => x.Email)
                 .NotEmpty().MinimumLength(3).MaximumLength(100).EmailAddress().WithMessage("O e-mail informado é inválido. Ex: string@email.com");

            RuleFor(x => x.Senha)
                .NotEmpty().MinimumLength(8).MaximumLength(100).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,100}$").WithMessage("A senha deve ter pelo menos uma letra minúscula, uma letra maiúscula, um número e um caractere especial.");
        }
    }
}
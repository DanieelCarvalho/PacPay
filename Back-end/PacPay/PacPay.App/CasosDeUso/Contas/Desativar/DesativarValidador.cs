using FluentValidation;

namespace PacPay.App.CasosDeUso.Contas.Desativar
{
    public sealed class DesativarValidador : AbstractValidator<DesativarRequest>
    {
        public DesativarValidador()
        {
            RuleFor(x => x.Senha)
                .NotEmpty().MinimumLength(8).MaximumLength(100).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,100}$").WithMessage("A senha deve ter pelo menos uma letra minúscula, uma letra maiúscula, um número e um caractere especial.");
        }
    }
}
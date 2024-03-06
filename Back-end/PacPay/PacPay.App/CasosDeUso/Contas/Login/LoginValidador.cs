using FluentValidation;

namespace PacPay.App.CasosDeUso.AdicionarConta
{
    public sealed class AdicionarContaValidador : AbstractValidator<LoginRequest>
    {
        public AdicionarContaValidador()
        {
            RuleFor(x => x.Documento).NotEmpty().MinimumLength(11).MaximumLength(11);
            RuleFor(x => x.Senha).NotEmpty().MinimumLength(8).MaximumLength(50);
        }
    }
}
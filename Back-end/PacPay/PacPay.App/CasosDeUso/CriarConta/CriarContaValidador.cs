using FluentValidation;

namespace PacPay.App.CasosDeUso.AdicionarConta
{
    public sealed class AdicionarContaValidador : AbstractValidator<CriarContaRequest>
    {
        public AdicionarContaValidador()
        {
            RuleFor(x => x.Cliente.Email).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Cliente.Nome).NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}
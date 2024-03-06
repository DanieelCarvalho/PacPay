using FluentValidation;

namespace PacPay.App.CasosDeUso.Contas.CriarConta
{
    public sealed class AdicionarContaValidador : AbstractValidator<CriarContaRequest>
    {
        public AdicionarContaValidador()
        {
            RuleFor(x => x.Cliente.Email).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Cliente.Nome).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Cliente.Documento).NotEmpty().MinimumLength(11).MaximumLength(11);
            RuleFor(x => x.Senha).NotEmpty().MinimumLength(8).MaximumLength(50);
        }
    }
}
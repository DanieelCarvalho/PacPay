using FluentValidation;

namespace PacPay.App.CasosDeUso.AdicionarCliente
{
    public sealed class AdicionarClienteValidador : AbstractValidator<AdicionarClienteRequest>
    {
        public AdicionarClienteValidador()
        {
            RuleFor(x => x.Email).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.Nome).NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}
using FluentValidation;

namespace PacPay.App.CasosDeUso.Operacoes.Transferencias
{
    public sealed class TransferenciaValidador : AbstractValidator<TransferenciaRequest>
    {
        public TransferenciaValidador()
        {
            RuleFor(x => x.Valor).NotEmpty().GreaterThan(0).WithMessage("O valor da transferência deve ser maior que zero.");
            RuleFor(x => x.ContaDestino).NotEmpty().Matches(@"^\d{11}$").WithMessage("A conta destino deve ser um CPF. Ex: 12345678912");
            RuleFor(x => x.Descricao).MaximumLength(100).WithMessage("A descrição da transferência deve ter no máximo 100 caracteres.");
        }
    }
}
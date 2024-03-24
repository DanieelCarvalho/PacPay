using FluentValidation;

namespace PacPay.App.CasosDeUso.Operacoes.Transferir
{
    public sealed class TransferirValidador : AbstractValidator<TransferirRequest>
    {
        public TransferirValidador()
        {
            RuleFor(x => x.Valor).NotEmpty().GreaterThan(0).WithMessage("O valor da transferência deve ser maior que zero.");
            RuleFor(x => x.ContaDestino).NotEmpty().Matches(@"^\d{11}$").WithMessage("A conta destino deve ser um CPF. Ex: 12345678912");
            RuleFor(x => x.Descricao).MaximumLength(100).WithMessage("A descrição da transferência deve ter no máximo 100 caracteres.");
        }
    }
}
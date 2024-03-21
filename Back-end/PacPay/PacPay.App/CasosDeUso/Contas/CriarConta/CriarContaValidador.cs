using FluentValidation;

namespace PacPay.App.CasosDeUso.Contas.CriarConta
{
    public sealed class CriarContaValidador : AbstractValidator<CriarContaRequest>
    {
        public CriarContaValidador()
        {
            RuleFor(x => x.Senha)
                .NotEmpty().MinimumLength(8).MaximumLength(100).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,100}$").WithMessage("A senha deve ter pelo menos uma letra minúscula, uma letra maiúscula, um número e um caractere especial.");

            RuleFor(x => x.Cpf)
                .NotEmpty().Matches(@"^\d{11}$").WithMessage("O CPF só pode conter números e deve ter exatamente 11 digitos");

            RuleFor(x => x.Telefone)
                .NotEmpty().Matches(@"^\d{11}$").WithMessage("O telefone só pode conter números e deve ter exatamente 11 digitos. Ex: 84988495843");

            RuleFor(x => x.Email)
                .NotEmpty().MinimumLength(3).MaximumLength(100).EmailAddress().WithMessage("O e-mail informado é inválido. Ex: string@email.com");

            RuleFor(x => x.Nome)
                .NotEmpty().MinimumLength(3).MaximumLength(100).WithMessage("O nome deve ter entre 3 e 100 caracteres.");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().Must(IdadeValida).WithMessage("É necessário ser maior de 18 anos. Ex: 01/01/2006");

            RuleFor(x => x.Cep)
                .NotEmpty().Matches(@"^\d{8}$").WithMessage("O CEP deve conter exatamente 8 dígitos. Ex: 02323123");

            RuleFor(x => x.Rua)
                .NotEmpty().MinimumLength(3).MaximumLength(100).WithMessage("A rua deve ter entre 3 e 100 caracteres.");

            RuleFor(x => x.Cidade)
                .NotEmpty().MinimumLength(3).MaximumLength(100).WithMessage("A cidade deve ter entre 3 e 100 caracteres.");

            RuleFor(x => x.Estado)
                .NotEmpty().MinimumLength(2).MaximumLength(2).Matches(@"^[A-Z]{2}$").WithMessage("O estado deve ter 2 caracteres e serem letras maiúsculas. Ex: SP");

            RuleFor(x => x.Numero)
              .Matches(@"^\d+$").WithMessage("O número deve conter apenas dígitos.");

            RuleFor(x => x.Complemento)
                .MaximumLength(100).WithMessage("O complemento deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Bairro)
                .MinimumLength(3).MaximumLength(100).WithMessage("O bairro deve ter entre 3 e 100 caracteres.");

            RuleFor(x => x.PontoDeReferencia)
                .MaximumLength(100).WithMessage("O ponto de referência deve ter no máximo 100 caracteres.");
        }

        private static bool IdadeValida(string dataNascimento)
        {
            try
            {
                var data = DateTime.Parse(dataNascimento);
                var idade = DateTime.Now.Year - data.Year;
                if (DateTime.Now.Month < data.Month || (DateTime.Now.Month == data.Month && DateTime.Now.Day < data.Day))
                    idade--;
                return idade >= 18 && idade <= 100;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
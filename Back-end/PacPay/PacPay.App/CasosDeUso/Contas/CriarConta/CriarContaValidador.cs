using FluentValidation;

namespace PacPay.App.CasosDeUso.Contas.CriarConta
{
    public sealed class AdicionarContaValidador : AbstractValidator<CriarContaRequest>
    {
        public AdicionarContaValidador()
        {
            RuleFor(x => x.Senha)
                .NotEmpty().MinimumLength(8).MaximumLength(100).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,100}$").WithMessage("A senha deve ter pelo menos uma letra minúscula, uma letra maiúscula, um número e um caractere especial.");

            RuleFor(x => x.Cliente.Cpf)
                .NotEmpty().Matches(@"^\d{11}$").WithMessage("O CPF só pode conter números e deve ter exatamente 11 digitos");

            RuleFor(x => x.Cliente.Email)
                .NotEmpty().MinimumLength(3).MaximumLength(50).EmailAddress().WithMessage("O e-mail informado é inválido. Ex: string@email.com");

            RuleFor(x => x.Cliente.Nome)
                .NotEmpty().MinimumLength(3).MaximumLength(100).WithMessage("O nome deve ter entre 3 e 100 caracteres.");

            RuleFor(x => x.Cliente.DataNascimento)
                .NotEmpty().Must(IdadeValida).WithMessage("É necessário ser maior de 18 anos. Ex: 01/01/2006");

            RuleFor(x => x.Cliente.Endereco.Cep)
                .NotEmpty().Matches(@"^\d{8}$").WithMessage("O CEP deve conter exatamente 8 dígitos. Ex: 02323123");

            RuleFor(x => x.Cliente.Endereco.Rua)
                .NotEmpty().MinimumLength(3).MaximumLength(100).WithMessage("A rua deve ter entre 3 e 100 caracteres.");

            RuleFor(x => x.Cliente.Endereco.Numero)
                .Matches(@"^\d+$").WithMessage("O número deve conter apenas dígitos.");

            RuleFor(x => x.Cliente.Endereco.Complemento)
                .MaximumLength(100).WithMessage("O complemento deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Cliente.Endereco.Bairro)
                .MinimumLength(3).MaximumLength(100).WithMessage("O bairro deve ter entre 3 e 100 caracteres.");

            RuleFor(x => x.Cliente.Endereco.Cidade)
                .NotEmpty().MinimumLength(3).MaximumLength(100).WithMessage("A cidade deve ter entre 3 e 100 caracteres.");

            RuleFor(x => x.Cliente.Endereco.Estado)
                .NotEmpty().MinimumLength(2).MaximumLength(2).Matches(@"^[A-Z]{2}$").WithMessage("O estado deve ter 2 caracteres e serem letras maiúsculas. Ex: SP");
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
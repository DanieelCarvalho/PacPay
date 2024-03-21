using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Excecoes;
using PacPay.Dominio.Excecoes.Mensagens;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.AdicionarConta
{
    public class Login(IRepositorioConta repositorioConta, IEncriptador encriptador, IAutenticador autenticador) : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly IEncriptador _encriptador = encriptador;
        private readonly IAutenticador _autenticador = autenticador;

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            FluentValidation.Results.ValidationResult resultado = new LoginValidador().Validate(request);
            if (!resultado.IsValid) throw new FluentValidation.ValidationException(resultado.Errors);

            Conta conta = await _repositorioConta.BuscarConta(request.Cpf, cancellationToken);

            if (conta.Ativa == false) throw new AppExcecao(ContaErr.ContaDesativada);

            bool autenticado = _encriptador.Comparar(request.Senha, conta.Senha);

            if (!autenticado) throw new AppExcecao(ContaErr.ContaDesativada);

            string token = _autenticador.GerarToken(conta.Id);

            return new LoginResponse { Nome = conta.Cliente.Nome, Token = $"Bearer {token}" };
        }
    }
}
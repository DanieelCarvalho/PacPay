using MediatR;
using PacPay.Dominio.Entidades;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.AdicionarConta
{
    public class Login(IRepositorioConta repositorioConta, IEncriptador encriptador, IAutenticacao autenticador) : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly IEncriptador _encriptador = encriptador;
        private readonly IAutenticacao _autenticador = autenticador;

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            Conta conta = await _repositorioConta.BuscarConta(request.Cpf, cancellationToken);

            bool autenticado = _encriptador.Comparar(request.Senha, conta.Senha);

            if (!autenticado) throw new Exception("Senha inválida!");

            string token = _autenticador.GerarToken(conta.Id);

            return new LoginResponse { Nome = conta.Cliente.Nome, Token = $"Bearer {token}" };
        }
    }
}
using AutoMapper;
using MediatR;
using PacPay.Dominio.Interfaces;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.CasosDeUso.AdicionarConta
{
    public class Login(IRepositorioConta repositorioConta, IMapper mapper, IEncriptador encriptador, IAutenticacao autenticador) : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IRepositorioConta _repositorioConta = repositorioConta;
        private readonly IMapper _mapper = mapper;
        private readonly IEncriptador _encriptador = encriptador;
        private readonly IAutenticacao _autenticador = autenticador;

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            string senha = await _repositorioConta.PegarSenha(request.Documento, cancellationToken);

            bool autenticado = _encriptador.Comparar(request.Senha, senha);

            if (!autenticado) throw new Exception("Senha inválida!");

            string token = _autenticador.GerarToken(request.Documento);

            return new LoginResponse { Token = token };
        }
    }
}
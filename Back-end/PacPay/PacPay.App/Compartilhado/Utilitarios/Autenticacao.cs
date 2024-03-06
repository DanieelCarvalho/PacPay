using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PacPay.Dominio.Interfaces.IUtilitarios;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PacPay.App.Compartilhado.Utilitarios
{
    public class Autenticacao(IConfiguration configuration) : IAutenticacao
    {
        private readonly string _chave = configuration["Chave"]!;

        public string GerarToken(string id)
        {
            byte[] cc = Encoding.ASCII.GetBytes(_chave);

            SecurityTokenDescriptor config = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new("Id", id)
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(cc), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();
            SecurityToken tokenCriado = jwtHandler.CreateToken(config);
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenCriado);

            return tokenString;
        }

        public string ValidarToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
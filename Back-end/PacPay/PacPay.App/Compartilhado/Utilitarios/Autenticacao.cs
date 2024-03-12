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

            JwtSecurityTokenHandler jwtHandler = new();
            SecurityToken tokenCriado = jwtHandler.CreateToken(config);
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenCriado);

            return tokenString;
        }

        public bool ValidarToken(string token)
        {
            byte[] cc = Encoding.ASCII.GetBytes(_chave);
            TokenValidationParameters parametrosDeValidacao = new()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(cc),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };

            JwtSecurityTokenHandler jwtHandler = new();
            try
            {
                jwtHandler.ValidateToken(token, parametrosDeValidacao, out SecurityToken tokenValidado);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
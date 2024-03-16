using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PacPay.Dominio.Interfaces.IUtilitarios;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PacPay.App.Compartilhado.Utilitarios
{
    public class Autenticacao(IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : IAutenticacao
    {
        private readonly string _chave = configuration["Chave"]!;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public string GerarToken(Guid id)
        {
            byte[] cc = Encoding.ASCII.GetBytes(_chave);

            SecurityTokenDescriptor config = new()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new("Id", id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(cc), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler jwtHandler = new();
            SecurityToken tokenCriado = jwtHandler.CreateToken(config);
            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokenCriado);

            return tokenString;
        }

        public string PegarId()
        {
            string token = _httpContextAccessor.HttpContext!.Request.Headers.Authorization!.Single()!.Split(" ").Last();
            JwtSecurityTokenHandler jwtHandler = new();
            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(token);
            Claim idClaim = jwtToken.Claims.First(claim => claim.Type == "Id");
            return idClaim.Value;
        }
    }
}
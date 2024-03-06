using DevOne.Security.Cryptography.BCrypt;
using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.Compartilhado.Utilitarios
{
    public class Encriptador : IEncriptador
    {
        public string Encriptar(string senha)
        {
            string hash = BCryptHelper.HashPassword(senha, BCryptHelper.GenerateSalt(16));

            return hash;
        }

        public bool Comparar(string senha, string hash)
        {
            return BCryptHelper.CheckPassword(senha, hash);
        }
    }
}
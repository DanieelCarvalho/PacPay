using PacPay.Dominio.Interfaces.IUtilitarios;

namespace PacPay.App.Compartilhado.Utilitarios
{
    public class Encriptador : IEncriptador
    {
        public string Encriptar(string senha)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(10);
            string hash = BCrypt.Net.BCrypt.HashPassword(senha, salt);

            return hash;
        }

        public bool Comparar(string senha, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(senha, hash);
        }
    }
}
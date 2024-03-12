namespace PacPay.Dominio.Interfaces.IUtilitarios
{
    public interface IAutenticacao
    {
        string GerarToken(string id);

        bool ValidarToken(string token);
    }
}
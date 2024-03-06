namespace PacPay.Dominio.Interfaces.IUtilitarios
{
    public interface IAutenticacao
    {
        string GerarToken(string id);

        string ValidarToken(string token);
    }
}
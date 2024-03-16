namespace PacPay.Dominio.Interfaces.IUtilitarios
{
    public interface IAutenticacao
    {
        string GerarToken(Guid id);

        string PegarId(string token);
    }
}
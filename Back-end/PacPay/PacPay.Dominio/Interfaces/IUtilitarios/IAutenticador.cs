namespace PacPay.Dominio.Interfaces.IUtilitarios
{
    public interface IAutenticador
    {
        string GerarToken(Guid id);

        string PegarId();
    }
}
namespace PacPay.Dominio.Interfaces.IUtilitarios
{
    public interface IEncriptador
    {
        string Encriptar(string senha);

        bool Comparar(string senha, string hash);
    }
}
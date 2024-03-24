namespace PacPay.Dominio.Excecoes
{
    public class Excecao(string mensagem, int statusCode) : Exception(mensagem)
    {
        public int StatusCode { get; set; } = statusCode;
    }
}
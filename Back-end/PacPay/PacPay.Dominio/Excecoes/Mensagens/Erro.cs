namespace PacPay.Dominio.Excecoes.Mensagens
{
    public class Erro(string mensagem, int statusCode) : Excecao(mensagem, statusCode)
    {
    }
}
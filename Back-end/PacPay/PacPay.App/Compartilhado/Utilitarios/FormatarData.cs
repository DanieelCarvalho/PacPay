namespace PacPay.App.Compartilhado.Utilitarios
{
    public static class FormatarData
    {
        public static string ParaString(DateTime data)
        {
            return data.ToLocalTime().ToString("dd/MM/yyyy HH:mm:hh");
        }
    }
}
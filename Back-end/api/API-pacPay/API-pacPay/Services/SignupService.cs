using API_pacPay.Domain.Dtos;
using System.Text.RegularExpressions;

namespace API_pacPay.Services;

public class SignupService
{
    private List<string> Resultado = new List<string>();

    public List<string> ValidacaoCadastro(SingUpDto validacao)
    {
        ValidarTexto(validacao.Nome, "NomeUsuario");
        ValidareEmail(validacao.Email);
        ValidarCpf(validacao.Cpf);
        ValidarAniversario(validacao.Aniversario);
        ValidarNumero(validacao.Telefone);

        ValidarCep(validacao.Cpf);
        ValidarTexto(validacao.Rua, "Endereco");
        ValidarNumeroEndereco(validacao.Numero);
        ValidarTexto(validacao.Cidade, "Bairro");
        ValidarTexto(validacao.Cidade, "Cidade");
        ValidarTexto(validacao.Cidade, "Estado");




        return Resultado;
    }

    private void ValidarTexto(string value, string baseNameError)
    {
        Regex regex = new Regex(@"[^A-Za-zÀ-ÖØ-öø-ſ\-'. ]");
        if (regex.IsMatch(value)) Resultado.Add($"{baseNameError}Error");
    }

    private void ValidareEmail(string value)
    {
        Regex regex = new Regex(@"^[^@]+@[^@]+\.(com|com\.br)$");
        if (!regex.IsMatch(value)) Resultado.Add("emailError");
    }

    private void ValidarCpf(string value)
    {
        Regex regex = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
        if (!regex.IsMatch(value)) Resultado.Add("cpfError");

    }

    private void ValidarAniversario(DateTime value)
    {
        DateTime today = DateTime.Today;
        int userAge = today.Year - value.Year;
        if (userAge < 18) Resultado.Add("AniversarioError");
    }


    private void ValidarNumero(string value)
    {
        
        Regex regex = new Regex(@"^\d{11}$");

        if (!regex.IsMatch(value))
        {
           
            Resultado.Add($"NumeroTelefoneError");
        }
    }

    private void ValidarCep(string value)
    {
        Regex regex = new Regex(@"^\d+$");
        if (!regex.IsMatch(value) && value.Length == 8)
            Resultado.Add("postalCodeError");
    }

    private void ValidarEnderoRua(string value, string baseNameError)
    {
        Regex regex = new Regex(@"[^A-Za-zÀ-ÖØ-öø-ſ\-'. ]");
        if (regex.IsMatch(value)) Resultado.Add($"{baseNameError}Error");
    }

    private void ValidarNumeroEndereco(string value)
    {
        Regex regex = new Regex(@"^[a-zA-ZÀ-ÿ0-9\s]*[^a-zA-ZÀ-ÿ0-9\s-][a-zA-ZÀ-ÿ0-9\s]*");
        if (regex.IsMatch(value)) Resultado.Add("addressNumberError");
    }

}

using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;

namespace API_pacPay.models;

public class User : Entity
{
    [Required]
    public string Nome { get; set; }
    public string Email { get; set; }

    public string Cpf { get; set; }
    public string Telefone { get; set; }
    public DateTime Aniversario { get; set; } = DateTime.Now;
    public string Senha { get; set; }

   //  public virtual Account Account { get; set; }
    public virtual Address Endereco { get; set; }


}

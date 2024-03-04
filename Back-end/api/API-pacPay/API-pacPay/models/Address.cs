using System.ComponentModel.DataAnnotations.Schema;

namespace API_pacPay.models;

public class Address : Entity
{
    public string Cep { get; set; }
    public string Rua { get; set; }
    public string Numero { get; set; } = "S/N";
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }

    [ForeignKey("User")]

    public int UserId { get; set; }
    public virtual User Usuario { get; set; }

}

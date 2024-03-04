using API_pacPay.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace API_pacPay.models
{

   
    public abstract class Entity : IEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}

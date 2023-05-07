using System.ComponentModel.DataAnnotations;

namespace WashingCar.DAL.Entities
{
    public class Entity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
    }
}

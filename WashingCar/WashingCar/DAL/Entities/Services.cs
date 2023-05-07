using System.ComponentModel.DataAnnotations;

namespace WashingCar.DAL.Entities
{
    public class Services : Entity
    {
        [Display (Name = "Nombre del Servicio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe ser de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es oblilgatorio.")]
        public string Name { get; set; }

        [Display(Name = "Precio del Servicio")]
        [Required(ErrorMessage = "El campo {0} es oblilgatorio.")]
        public float Price { get; set; }
    }
}

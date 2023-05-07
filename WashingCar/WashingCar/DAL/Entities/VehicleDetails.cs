using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WashingCar.DAL.Entities
{
    public class VehicleDetails : Entity
    {
        [Display(Name = "Fecha del Pedido")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Fecha de Entrega del Vehiculo")]
        public DateTime DeliveryDate { get; set; }
    }
}

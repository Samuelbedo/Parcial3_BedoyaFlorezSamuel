using WashingCar.DAL.Entities;

namespace WashingCar.Models
{
    public class VehicleViewModel : Vehicle
    {
        public Guid ServicesId { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using WashingCar.DAL.Entities;

namespace WashingCar.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<Services> Services { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleDetails> VehiclesDetails { get; set; }

    }
}

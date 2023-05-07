﻿using System.Net.Sockets;
using WashingCar.DAL.Entities;

namespace WashingCar.DAL
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;

        public SeederDb(DataBaseContext context)
        {
            _context = context;
        }

        public async Task SeederAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await PopulateServicesAsync();

            await _context.SaveChangesAsync();
        }

        private async Task PopulateServicesAsync()
        {
            if (!_context.Services.Any())
            {
                _context.Services.Add(new Services { Name = "Lavada Simple", Price = 25000});
                _context.Services.Add(new Services { Name = "Lavada + Polishada", Price = 50000 });
                _context.Services.Add(new Services { Name = "Lavada + Aspirada de Cojineria", Price = 30000 });
                _context.Services.Add(new Services { Name = "Lavada Full", Price = 65000 });
                _context.Services.Add(new Services { Name = "Lavada en seco del Motor", Price = 80000 });
                _context.Services.Add(new Services { Name = "Lavada del Chasis", Price = 90000 });
            }
        }
    }
}

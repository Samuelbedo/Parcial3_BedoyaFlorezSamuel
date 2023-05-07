using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WashingCar.DAL;
using WashingCar.DAL.Entities;
using WashingCar.Models;

namespace WashingCar.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataBaseContext _context;

        public ServicesController(DataBaseContext context)
        {
            _context = context;
        }

        private async Task<Services> GetServiceById(Guid? serviceId)
        {
            return await _context.Services
                .Include(c => c.Vehicles)
                .ThenInclude(s => s.VehicleDetails)
                .FirstOrDefaultAsync(c => c.Id == serviceId);
        }

        private async Task<Vehicle> GetVehicleById(Guid? vehicleId)
        {
            return await _context.Vehicles
                .Include(s => s.Services)
                .Include(c => c.VehicleDetails)
                .FirstOrDefaultAsync(c => c.Id == vehicleId);
        }


        public async Task<IActionResult> Index()
        {
              return _context.Services != null ? 
                          View(await _context.Services.ToListAsync()) :
                          Problem("Entity set 'DataBaseContext.Services'  is null.");
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var services = await _context.Services
                .FirstOrDefaultAsync(m => m.Id == id);
            if (services == null)
            {
                return NotFound();
            }

            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Services services)
        {
            if (ModelState.IsValid)
            {
                services.Id = Guid.NewGuid();
                _context.Add(services);                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(services);
        }

        private bool ServicesExists(Guid id)
        {
          return (_context.Services?.Any(e => e.Id == id)).GetValueOrDefault();
        }





        [HttpGet]
        public async Task<IActionResult> AddVehicle(Guid? servicesId)
        {
            if (servicesId == null) return NotFound();

            Services services = await GetServiceById(servicesId);

            if (services == null) return NotFound();

            VehicleViewModel vehicleViweModel = new()
            {
                ServicesId = services.Id,
            };

            return View(vehicleViweModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVehicle(VehicleViewModel vehicleViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Vehicle vehicle = new Vehicle()
                    {
                        VehicleDetails = new List<VehicleDetails>(),
                        Services = await GetServiceById(vehicleViewModel.ServicesId),
                        Owner = vehicleViewModel.Owner,
                        NumberPlate = vehicleViewModel.NumberPlate,
                    };

                    _context.Add(vehicle);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { vehicleViewModel.ServicesId });
                }
                //catch (DbUpdateException dbUpdateException)
                //{
                //    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                //    {
                //        ModelState.AddModelError(string.Empty, "Ya existe un Dpto/Estado con el mismo nombre en este país.");
                //    }
                //    else
                //    {
                //        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                //    }
                //}
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(vehicleViewModel);
        }

    }
}

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

        // GET: Services
        public async Task<IActionResult> Index()
        {
              return _context.Services != null ? 
                          View(await _context.Services.ToListAsync()) :
                          Problem("Entity set 'DataBaseContext.Services'  is null.");
        }

        // GET: Services/Details/5
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

        // GET: Services/Create
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

            Services services = await _context.Services.FindAsync(servicesId);

            if (services == null) return NotFound();

            VehicleViewModel vehicleViweModel = new()
            {
                ServicesId = services.Id,
            };

            return View(vehicleViweModel);
        }
    }
}

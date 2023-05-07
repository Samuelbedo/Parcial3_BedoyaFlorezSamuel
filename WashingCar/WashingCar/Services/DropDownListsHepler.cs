using Microsoft.AspNetCore.Mvc.Rendering;
using WashingCar.DAL;
using WashingCar.Helpers;

namespace WashingCar.Services
{
    public class DropDownListsHepler : IDropDownListsHelper
    { 
        private readonly DataBaseContext _context;

        public DropDownListsHepler(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetDDLServicesAsync()
        {
            List<SelectListItem> listServices = await _context.Services
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString(), //Guid                    
                })
                .ToListAsync();

            listServices.Insert(0, new SelectListItem
            {
                Text = "Selecione un servicio....",
                Value = "0",
            });

            return listServices;
        }
    }
}

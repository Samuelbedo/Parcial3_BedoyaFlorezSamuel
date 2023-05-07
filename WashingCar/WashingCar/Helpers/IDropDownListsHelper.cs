using Microsoft.AspNetCore.Mvc.Rendering;

namespace WashingCar.Helpers
{
    public interface IDropDownListsHelper
    {
        Task<IEnumerable<SelectListItem>> GetDDLServicesAsync();
    }
}

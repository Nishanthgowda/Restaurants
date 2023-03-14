using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturant.Core;
using Resturant.Data;

namespace OrderToFood.Pages.Resturants
{
    public class DetailModel : PageModel
    {
        public ResturantsHotel resturant;
        private readonly IResturantData resturantData;
        [TempData]
        public string Message { get; set; }
        public DetailModel(IResturantData resturantData)
        {
            this.resturantData = resturantData;
        }
        public IActionResult OnGet(int resturantId)
        {
            resturant = resturantData.GetResturantbyId(resturantId);
            if(resturant == null)
            {
                return RedirectToPage("./NotFound404");
            }
            return Page();
        }
    }
}

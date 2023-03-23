using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturant.Core;
using Resturant.Data;

namespace OrderToFood.Pages.Resturants
{
    public class DeleteModel : PageModel
    {
        public ResturantsHotel Resturant { get; set; }
        public IResturantData resturant { get; }

        public DeleteModel(IResturantData resturant)
        {
            this.resturant = resturant;
        }

        

        public IActionResult OnGet(int resturantId)
        {
            Resturant = resturant.GetResturantbyId(resturantId);
            if(Resturant == null)
            {
                return RedirectToPage("./NotFound404");
            }
            return Page();
        }

        public IActionResult OnPost(int resturantId)
        {
            Resturant = resturant.Delete(resturantId);            
            if(Resturant == null)
            {
                return RedirectToPage("./NotFound404");
            }
            resturant.commit();
            return RedirectToPage("./List");
        }
    }
}

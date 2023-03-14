using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant.Core;
using Resturant.Data;

namespace OrderToFood.Pages.Resturants
{
    public class EditModel : PageModel
    {
        private readonly IResturantData resturantData;
        private readonly IHtmlHelper htmlHelper;
        public IEnumerable<SelectListItem> Cuisines;

        [BindProperty]
        public ResturantsHotel resturant { get; set; }

        public EditModel(IResturantData resturantData,IHtmlHelper htmlHelper)
        {
            this.resturantData = resturantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? resturantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if(resturantId.HasValue)
            {
                resturant = resturantData.GetResturantbyId(resturantId.Value);
            }
            else
            {
                resturant = new ResturantsHotel();
            }
            
            if(resturant == null)
            {
                return RedirectToPage("./NotFound404");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();                
            }
            if(resturant.Id> 0)
            {
                TempData["Message"] = "Updated the resturant";
                resturantData.Update(resturant);
            }
            else
            {
                TempData["Message"] = "Added new resturant";
                resturantData.Create(resturant);
            }
           
            resturantData.commit();
            return RedirectToPage("./Detail", new { resturantId = resturant.Id });
        }
    }
}

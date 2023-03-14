using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Resturant.Data;
using Resturant.Core;

namespace OrderToFood.Pages.Resturants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IResturantData resturantData;
        public IEnumerable<ResturantsHotel> resturants { get; set; }
        public string message { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config,IResturantData resturantData)
        {
            this._config = config;
            this.resturantData = resturantData;
        }
        public void OnGet()
        {
            message = "Welcome";
            resturants = resturantData.GetResturantsbyname(SearchTerm);
        }
    }
}

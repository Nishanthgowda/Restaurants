using Microsoft.AspNetCore.Mvc;
using Resturant.Data;

namespace OrderToFood.ViewComponents
{
    public class ResturantViewComponent:ViewComponent
    {
        private readonly IResturantData resturantData;

        public ResturantViewComponent(IResturantData resturantData)
        {
            this.resturantData = resturantData;
        }

        public IViewComponentResult Invoke()
        {
            var count  = resturantData.getResturantCount();
            return View(count);
        }
    }
}

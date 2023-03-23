using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resturant.Core;

namespace Resturant.Data
{
    public interface IResturantData
    {
        IEnumerable<ResturantsHotel> GetResturantsbyname(string name);
        ResturantsHotel GetResturantbyId(int id);

        ResturantsHotel Update(ResturantsHotel updatedRes);

        ResturantsHotel Create(ResturantsHotel resturantsHotel);
        ResturantsHotel Delete(int resturantId);
        int commit();
        int getResturantCount();
    }
}

using Resturant.Core;

namespace Resturant.Data
{
    public class InMemoryData : IResturantData
    {
        List<ResturantsHotel> resturants;
        public InMemoryData()
        {
            resturants = new List<ResturantsHotel>
            {
                new ResturantsHotel {Id=1,Name="Pizzeria",Location="New York",CusineType=CuisineType.Italian},
                 new ResturantsHotel {Id=2,Name="Mahesh Prasad",Location="New York",CusineType=CuisineType.Indian},
                  new ResturantsHotel {Id=3,Name="TacoBell",Location="New York",CusineType=CuisineType.Mexican}

            };
        }
        public IEnumerable<ResturantsHotel> GetResturantsbyname(string name)
        {
            return from resturant in resturants
                   where string.IsNullOrEmpty(name) || resturant.Name.ToLower().Equals(name.ToLower())
                   orderby resturant.Name
                   select resturant;
        }
        public ResturantsHotel GetResturantbyId(int id)
        {
            return resturants.FirstOrDefault(x => x.Id == id);
        }

        public ResturantsHotel Update(ResturantsHotel updatedRes)
        {
            var res = resturants.FirstOrDefault(x => x.Id == updatedRes.Id);
            if(res != null)
            {
                res.Name = updatedRes.Name;
                res.Location = updatedRes.Location;
                res.CusineType = updatedRes.CusineType;
            }
            return res;
        }

        public int commit()
        {
            return 0;
        }

        public ResturantsHotel Create(ResturantsHotel resturantsHotel)
        {
            resturants.Add(resturantsHotel);
            resturantsHotel.Id = resturants.Max(i => i.Id)+1;
            return resturantsHotel;
        }

        public ResturantsHotel Delete(int resturantId)
        {
            var resturant = resturants.FirstOrDefault(x => x.Id == resturantId);
            if(resturant != null)
            {
                resturants.Remove(resturant);
            }
            return resturant;
        }

        public int getResturantCount()
        {
           return resturants.Count();
        }
    }
}

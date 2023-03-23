using Resturant.Core;
using System.Linq;

namespace Resturant.Data
{
    public class SqlResturantData : IResturantData
    {
        public OdeToFoodDbContext db { get; }
        public SqlResturantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        

        public int commit()
        {
            return db.SaveChanges();
        }

        public ResturantsHotel Create(ResturantsHotel resturantsHotel)
        {
            db.Add(resturantsHotel);
            commit();
            return resturantsHotel;
        }

        public ResturantsHotel Delete(int resturantId)
        {
            var resturant = GetResturantbyId(resturantId);
            if(resturant != null)
            {
                db.Remove(resturant);
                commit();
            }
               
            return resturant;
        }

        public ResturantsHotel GetResturantbyId(int id)
        {
            return db.Resturants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ResturantsHotel> GetResturantsbyname(string name)
        {
            var query =  from r in db.Resturants
                                where r.Name.Equals(name) || string.IsNullOrEmpty(name)
                                orderby r.Name
                                select r;
            return query;  
        }

        public ResturantsHotel Update(ResturantsHotel updatedRes)
        {
            var entity = db.Resturants.Attach(updatedRes);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            commit();
            return updatedRes;
        }

        public int getResturantCount()
        {
            return db.Resturants.Count();
        }
    }
}

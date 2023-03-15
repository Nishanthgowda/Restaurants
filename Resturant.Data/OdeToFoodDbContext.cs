using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resturant.Core;

namespace Resturant.Data
{
    public class OdeToFoodDbContext:DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options):base(options)
        {

        }
        public DbSet<ResturantsHotel> Resturants { get; set; }
    }
}

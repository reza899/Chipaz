using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingDatabase.Models
{
    public class CookingDbContext:DbContext
    {
        public CookingDbContext(DbContextOptions<CookingDbContext> option):base(option)
        {

        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingDatabase.Models
{
    public class FoodIndexModel
    {
        public IEnumerable<Food> Foods { get; set; }
        public  MadenType Maden { get; set; }
    }
}

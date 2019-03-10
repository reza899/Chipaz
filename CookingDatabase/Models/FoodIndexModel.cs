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
        public SortType Sort { get; set; }
        public OrderType Order { get; set; }
        public string Search { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
    }
}

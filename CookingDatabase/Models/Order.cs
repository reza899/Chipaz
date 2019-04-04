using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookingDatabase.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        
        public string PhoneNumber { get; set; }


        public int BookId { get; set; }
        public decimal Price { get; set; }

        public DateTime OrderDate { get; set; }
        public OrderState State { get; set; }
    }

    public enum OrderState
    {
        New=0,
        Delivered=1
    }
}

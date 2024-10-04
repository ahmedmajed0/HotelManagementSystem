using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class OrderMenuItem
    {
        public int FoodId { get; set; }
        public string Image { get; set; }
        public string FoodName { get; set; }
        public decimal Price { get; set; }
        public int qty { get; set; }
        public decimal Total { get; set; }
    }
}

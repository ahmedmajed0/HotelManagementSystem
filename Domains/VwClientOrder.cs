using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class VwClientOrder
    {
        public int OrderId { get; set; }
        public int? ClientFoodId { get; set; }
        public string FoodName { get; set; }
        public decimal Price { get; set; }
        public int qty { get; set; }
        public decimal Total { get; set; }
        public int RoomNo { get; set; }
        public string GuestPhone { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class TbOrder
    {
        public int OrderId { get; set; }
        public int? ClientFoodId { get; set; }
        public int FoodId { get; set; }
        public string Image { get; set; }
        public string FoodName { get; set; }
        public decimal Price { get; set; }
        public int qty { get; set; }
        public decimal Total { get; set; }

        public virtual TbClientFood ClientFood { get; set; }
    }
}

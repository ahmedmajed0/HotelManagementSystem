using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bl;
using Domains;

namespace HotelManagement.Models
{
    public class OrderMenu
    {
        public OrderMenu()
        {
            listOrders = new List<TbOrder>();
        }
        public List<TbOrder> listOrders { get; set; }
        public decimal Total { get; set; }
    }
}

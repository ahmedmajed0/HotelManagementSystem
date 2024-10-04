using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Models
{
    public class NormalOrdersModel
    {
        public NormalOrdersModel()
        {
            List<VwClientOrder> clientOrders = new List<VwClientOrder>();
            List<VwClientOrder> SampleOrders = new List<VwClientOrder>();
        }

       public  List<VwClientOrder> clientOrders { get; set; }
        public List<VwClientOrder> SampleOrders { get; set; }
    }
}

using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Models
{
    public class CheckOutModel
    {
        public CheckOutModel()
        {
            lstFoodUnpaid = new List<VwClientFoodPayment>();
        }

        public List<VwClientFoodPayment> lstFoodUnpaid { get; set; }

        public int RoomNumber { get; set; }
        public int RservationId { get; set; }

        public int clFoodId { get; set; }
    }
}

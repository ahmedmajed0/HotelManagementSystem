using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class VwClientFoodPayment
    {
        public int ClientFoodId { get; set; }
        public int RoomNo { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPaidPrice { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
    }
}

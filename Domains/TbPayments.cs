using System;
using System.Collections.Generic;

namespace Domains
{
    public partial class TbPayments
    {
        public int PaymentId { get; set; }
        public int? ReservationId { get; set; }
        public int? ClientFoodId { get; set; }
        public string Method { get; set; }
        public decimal TotalPaidPrice { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
        

        public virtual TbClientFood ClientFood { get; set; }
        public virtual TbReservations Reservation { get; set; }
    }
}

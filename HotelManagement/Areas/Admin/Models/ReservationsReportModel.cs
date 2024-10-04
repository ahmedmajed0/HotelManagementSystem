using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bl;
using Domains;

namespace HotelManagement.Areas.Admin.Models
{
    public class ReservationsReportModel
    {
        public ReservationsReportModel()
        {
            Reservations = new List<VwRoomReservation>();
        }

        public List<VwRoomReservation> Reservations { get; set; }
        public decimal Total { get; set; }
    }
}

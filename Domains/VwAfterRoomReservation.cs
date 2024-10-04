using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class VwAfterRoomReservation
    {
        public int ReservationId { get; set; }
        public string ClientName { get; set; }
        public DateTime ArrivingDate { get; set; }

        public DateTime LeavingDate { get; set; }
        public byte RoomFloor { get; set; }

        public decimal RoomPrice { get; set; }
        public decimal? Discount { get; set; }

        public int RoomNo { get; set; }
        public string RoomPassword { get; set; }
    }
}

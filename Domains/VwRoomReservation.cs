using System;
using System.Collections.Generic;
using System.Text;


namespace Domains
{
    public class VwRoomReservation
    {
        public DateTime ArrivingDate { get; set; }

        public DateTime LeavingDate { get; set; }
        public int RoomNo { get; set; }
        public string RoomView { get; set; }
        public decimal RoomPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

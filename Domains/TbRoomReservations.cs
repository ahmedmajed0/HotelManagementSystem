using System;
using System.Collections.Generic;

namespace Domains
{
    public partial class TbRoomReservations
    {
        public int RoomReservationId { get; set; }
        public int? RoomId { get; set; }
        public int? ReservationId { get; set; }

        public virtual TbReservations Reservation { get; set; }
        public virtual TbRooms Room { get; set; }
    }
}

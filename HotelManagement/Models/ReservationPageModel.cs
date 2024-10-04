using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class ReservationPageModel
    {
        public int RoomId { get; set; }
        public int RoomNo { get; set; }
        public TbReservations Reservation { get; set; }
        public TbClients Client { get; set; }
    }
}

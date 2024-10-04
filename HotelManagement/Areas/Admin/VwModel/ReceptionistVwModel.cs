using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.VwModel
{
    public class ReceptionistVwModel
    {
        public int ReservationsNo { get; set; }
        public int GuestsNo { get; set; }
        public int CheckedRooms { get; set; }
        public int AvailableRooms { get; set; }
    }
}

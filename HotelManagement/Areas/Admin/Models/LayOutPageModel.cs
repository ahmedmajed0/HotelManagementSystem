using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Models
{
    public class LayOutPageModel
    {
        public int GustsNumber { get; set; }
        public int CheckInNumber { get; set; }
        public int CheckOutNumber { get; set; }
        public int ComingReservationsNumber { get; set; }
        public int HousekeepingNumber { get; set; }
        public int DailyHkNumber { get; set; }
        public int MeelsNumber { get; set; }
    }
}

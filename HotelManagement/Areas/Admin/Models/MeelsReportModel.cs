using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bl;
using Domains;

namespace HotelManagement.Areas.Admin.Models
{
    public class MeelsReportModel
    {
        public MeelsReportModel()
        {
            meelNumber = new List<VwMeelNumber>();
            RoomMeels = new List<VwRoomMeel>();
        }
        public List<VwMeelNumber> meelNumber { get; set; }

        public List<VwRoomMeel> RoomMeels{ get; set; }

    }
}

using System;
using Domains;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class RoomModel
    {
        public RoomModel()
        {
            lstRelatedRooms = new List<TbRooms>();
            lstBigRooms = new List<TbRooms>();
        }

        public TbRooms SingleRoom { get; set; }
        public List<TbRooms> lstRelatedRooms { get; set; }
        public List<TbRooms> lstBigRooms { get; set; }
    }
}

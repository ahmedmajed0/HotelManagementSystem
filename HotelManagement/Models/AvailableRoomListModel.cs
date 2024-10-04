using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bl;
using Domains;

namespace HotelManagement.Models
{
    public class AvailableRoomListModel
    {
        public AvailableRoomListModel()
        {
            listAllRooms = new List<TbRooms>();
            listviews = new List<TbRooms>();
        }

        public List<TbRooms> listAllRooms { get; set; }
        public List<TbRooms> listviews { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;

namespace HotelManagement.Models
{
    public class HomePageModel
    {
        public HomePageModel()
        {
            listCoupleRooms = new List<TbRooms>();
            listAllRooms = new List<TbRooms>();
            listviews = new List<TbRooms>();
            listBigRooms = new List<TbRooms>();
        }
        public List<TbRooms> listCoupleRooms { get; set; }
        public List<TbRooms> listAllRooms { get; set; }
        public List<TbRooms> listviews { get; set; }
        public List<TbRooms> listBigRooms { get; set; }

        public CheckRoomAvailability checkRoom { get; set; }
    }
}

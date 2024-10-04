using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class VwCheckingRoomAvailablity
    {
        public int RoomId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ViewId { get; set; }

        public byte RoomFloor { get; set; }

        public int RoomNo { get; set; }

        public string RoomView { get; set; }
        public string RoomCleaner { get; set; }

        public string ImageName { get; set; }

        public decimal RoomPrice { get; set; }

        public byte NoOfPersons { get; set; }

        public byte NoOfBeds { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public string Status { get; set; }


        public DateTime ArrivingDate { get; set; }

        public DateTime LeavingDate { get; set; }

    }
}

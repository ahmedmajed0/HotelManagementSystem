using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class VwRoomEmployee
    {
        public int RoomNo { get; set; }
        public byte NoOfBeds { get; set; }
        public byte NoOfPersons { get; set; }
        public int EmployeeNo { get; set; }

        public string EmployeeName { get; set; }
    }
}

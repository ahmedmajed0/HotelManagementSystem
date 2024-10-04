using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class CheckRoomAvailability
    {
        [Required]
        
        public DateTime ArrivingDate { get; set; }
        [Required]
        public DateTime LeavingDate { get; set; }

        [Required]
        [Range(1,5, ErrorMessage = "Beds number only from 1 to 5")]
        public int BedsNumber { get; set; }
    }
}

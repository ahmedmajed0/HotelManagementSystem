using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class RoomPasswordVwModel
    {
        [Required (ErrorMessage ="Please Enter room password")]
        public string RoomPassword { get; set; }
    }
}

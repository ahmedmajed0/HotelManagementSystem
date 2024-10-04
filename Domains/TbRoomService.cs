using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public class TbRoomService
    {
        public int RoomServiceId { get; set; }

        [Required(ErrorMessage = "Please Enter Room Number")]
        public int RoomNo { get; set; }

        [Required(ErrorMessage = "Please select the day of cleaning your room")]
        public string CleaningDay { get; set; }

        [Required(ErrorMessage = "Please Enter the Hour of cleaning your Room ")]
        public int RecievingHour { get; set; }

        [Required(ErrorMessage = "Please Enter the Time PM or AM ")]
        public string PM { get; set; }

        public string Status { get; set; }

    }
}

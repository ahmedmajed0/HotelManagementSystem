using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public partial class TbRooms
    {
        public TbRooms()
        {
            TbRoomReservations = new HashSet<TbRoomReservations>();
        }

        public int RoomId { get; set; }
        public int? EmployeeId { get; set; }
        public int? ViewId { get; set; }

        [Required(ErrorMessage ="Please Enter Room Floor")]
        public byte RoomFloor { get; set; }

        [Required(ErrorMessage = "Please Enter Room Number")]
        public int RoomNo { get; set; }

        public string RoomView { get; set; }
        public string RoomCleaner { get; set; }
        public string RoomPassword { get; set; }

        [MaxLength(200)]
        public string ImageName { get; set; }

        [Required(ErrorMessage = "Please Enter Room Price")]
        public decimal RoomPrice { get; set; }

        [Required(ErrorMessage = "Please Enter The Number Of persons for this Room ")] 
        public byte NoOfPersons { get; set; }

        [Required(ErrorMessage = "Please Enter The Number Of bed available for this Room")]  
        public byte NoOfBeds { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Please Enter Room Status")]
        public string Status { get; set; }

        public virtual TbEmployees Employee { get; set; }
        public virtual TbViews Views { get; set; }
        public virtual ICollection<TbRoomReservations> TbRoomReservations { get; set; }
    }
}

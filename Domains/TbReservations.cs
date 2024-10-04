using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public partial class TbReservations
    {
        public TbReservations()
        {
            TbPayments = new HashSet<TbPayments>();
            TbRoomReservations = new HashSet<TbRoomReservations>();
        }
        public int ReservationId { get; set; }
        public int? ClientId { get; set; }
        public int? MeelId { get; set; }
        public int RoomId { get; set; }

        public decimal MeelPrice { get; set; }

        [Required (ErrorMessage ="Please Enter Adults number")]
        public byte AdultsNo { get; set; }

        public byte ChildNo { get; set; }

        public int Nights { get; set; }
        [Required(ErrorMessage = "Please Enter Arrival Date")]
        public DateTime ArrivingDate { get; set; }

        [Required(ErrorMessage = "Please Enter Departure Date")]
        public DateTime LeavingDate { get; set; }

        [Range(0,1000, ErrorMessage = "Numbers less than zero are not allowed and numbers greater than 1000")]
        public decimal? Discount { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }


        public virtual TbClients Client { get; set; }
        public virtual TbMeels Meel { get; set; }
        public virtual ICollection<TbPayments> TbPayments { get; set; }
        public virtual ICollection<TbRoomReservations> TbRoomReservations { get; set; }
    }
}

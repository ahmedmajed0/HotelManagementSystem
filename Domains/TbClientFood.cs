using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public partial class TbClientFood
    {
        public TbClientFood()
        {
            TbPayments = new HashSet<TbPayments>();
        }

        public int ClientFoodId { get; set; }
        [Required (ErrorMessage ="Please Enter Room Number")]
        public int RoomNo { get; set; }

        [Required(ErrorMessage = "Please Enter Your Phone number")]
        [Phone]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Please Enter the right Phone number which is 11 number")]
        public string GuestPhone { get; set; }
        public decimal Price { get; set; }

        public byte RecievingHour { get; set; }

        public byte RecievingMinutes { get; set; }

        public string PM { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        public virtual ICollection<TbPayments> TbPayments { get; set; }
        public virtual ICollection<TbOrder> Orders { get; set; }
    }
}

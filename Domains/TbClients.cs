using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public partial class TbClients
    {
        public TbClients()
        {
            TbReservations = new HashSet<TbReservations>();
        }

        public int ClientId { get; set; }
        [Required(ErrorMessage = "Please Enter Guest Name")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "Please Enter Guest Nationality")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Please Select Guest Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Guest Phone")]
        [Phone]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Please Enter the right Phone number which is 11 number")]
        public string Phone { get; set; }
        public string City { get; set; }

        public virtual ICollection<TbReservations> TbReservations { get; set; }
    }
}

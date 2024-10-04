using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public partial class TbMeels
    {
        public TbMeels()
        {
            TbReservations = new HashSet<TbReservations>();
        }

        public int MeelId { get; set; }


        [Required(ErrorMessage ="Please Enter Meel Name")]
        public string MeelName { get; set; }

        [Required(ErrorMessage = "Please Enter Meel Time Like 12 pm")]
        public string MeelTime { get; set; }

        public string MeelDetails { get; set; }

        [Required(ErrorMessage = "Please Enter Meel Price")]
        public decimal MeelPrice { get; set; }

        public virtual ICollection<TbReservations> TbReservations { get; set; }
    }
}

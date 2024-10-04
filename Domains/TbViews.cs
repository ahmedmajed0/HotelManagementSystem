using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public class TbViews
    {
        public int ViewId { get; set; }

        [Required(ErrorMessage ="Please Enter View")]
        public string ViewName { get; set; }

        public virtual TbRooms Rooms { get; set; }
    }
}

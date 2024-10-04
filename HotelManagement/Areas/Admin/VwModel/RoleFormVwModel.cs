using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.VwModel
{
    public class RoleFormVwModel
    {
        [Required(ErrorMessage ="Please Enter Role"), StringLength(256)]
        public string Name { get; set; }
    }
}

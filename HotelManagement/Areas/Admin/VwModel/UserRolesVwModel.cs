using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.VwModel
{
    public class UserRolesVwModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }

        public List<CheckBoxVwModel> Roles { get; set; }
    }
}

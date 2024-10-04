using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.VwModel
{
    public class RolePermissionsVwModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public List<CheckBoxVwModel> Permissions { get; set; }
    }
}

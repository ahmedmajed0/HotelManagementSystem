using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.Constants
{
    public static class Permissions
    {
        public static List<string> GetPermissionsList(string modul)
        {
            return new List<string>()
            { 
                $"Permissions.{modul}.View",
                $"Permissions.{modul}.Create",
                $"Permissions.{modul}.Edit",
                $"Permissions.{modul}.Delete",
            };

        }

        public static List<string> GetAllPermissions()
        {
            var allPermissions = new List<string>();

            var dbtables = Enum.GetValues(typeof(DbTables));

            foreach (var modul in dbtables)
                allPermissions.AddRange(GetPermissionsList(modul.ToString()));

            return (allPermissions);

        }
    }
}

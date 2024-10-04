using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.VwModel
{
    public class HomePageVwModel
    {
        public HomePageVwModel()
        {
            Admin = new AdminVwModel();
            DataEntry = new DataEntryVwModel();
            Restaurant = new RestaurantVwModel();
            Receptionist = new ReceptionistVwModel();
            BasicUser = new BasicUserVwModel();
        }
        public AdminVwModel Admin { get; set; }
        public DataEntryVwModel DataEntry { get; set; }
        public RestaurantVwModel Restaurant { get; set; }
        public ReceptionistVwModel Receptionist { get; set; }
        public BasicUserVwModel BasicUser { get; set; }
    }
}

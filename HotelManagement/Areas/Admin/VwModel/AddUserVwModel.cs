using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Areas.Admin.VwModel
{
    public class AddUserVwModel
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }



        [Required]
        [StringLength(50,ErrorMessage = "The Minimum must be ate least 8", MinimumLength =8)]
        public string Password { get; set; }

        [Required]
        [Compare("Password",ErrorMessage ="The Password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public List<CheckBoxVwModel> Roles { get; set; }
    }
}

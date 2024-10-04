using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bl
{
    public class ApplicationUser: IdentityUser
    {
        [Required (ErrorMessage ="Please Enter First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }
    }
}

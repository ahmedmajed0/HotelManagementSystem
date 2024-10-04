using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public partial class TbEmployees
    {
        public TbEmployees()
        {
            TbRooms = new HashSet<TbRooms>();
    }
        public int EmployeeId { get; set; }       
        public int EmployeeNo { get; set; }

        [Required(ErrorMessage ="Please Enter Employee Name")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage ="Please select DepartMent")]
        public string DepartMent { get; set; }


        [Required(ErrorMessage = "Please Enter Salary")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Please Enter National Id")]
        [Phone(ErrorMessage = "Please Enter a valid National Id with 14 numbers")]
        [StringLength(14,MinimumLength =14,ErrorMessage = "Wrong National Id Enter 14 numbers")]
        public string NationalId { get; set; }

        [Required(ErrorMessage = "Please Enter Job Name")]
        public string JobName { get; set; }


        [Required(ErrorMessage = "Please Enter Date Of Birth")]   
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public virtual ICollection<TbRooms> TbRooms { get; set; }
    }
}

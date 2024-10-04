using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public partial class TbFood
    {

        public int FoodId { get; set; }

        [Required(ErrorMessage = "Please Select Category")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [Required(ErrorMessage ="Please Enter Food Name")]
        public string FoodName { get; set; }

        [Required(ErrorMessage = "Please Enter Food Price")]
        public decimal FoodPrice { get; set; }


        //[Required(ErrorMessage = "Please Enter Food Image")]
        [MaxLength(200)]
        public string FoodImage { get; set; }
        public string FoodDescription { get; set; }

        public virtual TbFoodCategory TbFoodCategory { get; set; }
    }
}

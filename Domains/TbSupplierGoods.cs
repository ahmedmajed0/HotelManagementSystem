using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public partial class TbSupplierGoods
    {
        public int SupplierGoodId { get; set; }
        [Required (ErrorMessage ="Please Select Supplier Name")]
        public int SupplierId { get; set; }
        public string SupplierrName { get; set; }

        [Required(ErrorMessage = "Please Enter Category")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Please Enter Quantity")]
        public double Quantity { get; set; }

        [Required(ErrorMessage = "Please Enter qunatity Unit")]
        public string QuantityUnit { get; set; }

        [Required(ErrorMessage = "Please Enter Total price")]
        public decimal Price { get; set; }

        public DateTime PaymentDate { get; set; }

        [Required(ErrorMessage = "Please Enter Date Of Arrival")]
        public DateTime DateOfArrival { get; set; }

        public virtual TbSuppliers Supplier { get; set; }
    }
}

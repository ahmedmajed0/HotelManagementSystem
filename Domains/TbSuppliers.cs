using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains
{
    public partial class TbSuppliers
    {
        public TbSuppliers()
        {
            TbSupplierGoods = new HashSet<TbSupplierGoods>();
        }

        
        public int SupplierId { get; set; }
        [Required(ErrorMessage ="Please Enter Supplier Name")]
        public string SupplierName { get; set; }
        [Required(ErrorMessage = "Please Enter Supplier Branch")]
        public string SupplierAddress { get; set; }
        [Required(ErrorMessage = "Please Enter Supplier Phone")]
        [Phone]
        [StringLength(11,MinimumLength = 11,ErrorMessage ="Please Enter the right Phone number which is 11 number")]
        public string SupplierPhone { get; set; }

        public virtual ICollection<TbSupplierGoods> TbSupplierGoods { get; set; }
    }
}

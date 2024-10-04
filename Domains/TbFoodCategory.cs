using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class TbFoodCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<TbFood> Food { get; set; }
    }
}

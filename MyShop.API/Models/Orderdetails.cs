using System;
using System.Collections.Generic;

namespace MyShop.API.Models
{
    public partial class Orderdetails
    {
        public int Orderid { get; set; }
        public int Productid { get; set; }
        public short? Qty { get; set; }
        public double? Discount { get; set; }

        public virtual Orders Order { get; set; }
    }
}

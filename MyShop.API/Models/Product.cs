using System;
using System.Collections.Generic;

namespace MyShop.API.Models
{
    public partial class Product
    {
        public int Productid { get; set; }
        public string Productname { get; set; }
        public int? Unitprice { get; set; }
        public short? Stock { get; set; }
    }
}

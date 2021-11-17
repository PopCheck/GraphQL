using System;
using System.Collections.Generic;

namespace MyShop.API.Models
{
    public partial class Customer
    {
        public int Customerid { get; set; }
        public string Companyname { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}

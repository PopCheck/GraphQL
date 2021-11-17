using System;
using System.Collections.Generic;

namespace MyShop.API.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Orderdetails = new HashSet<Orderdetails>();
        }

        public int Orderid { get; set; }
        public DateTime Orderdate { get; set; }
        public int Customerid { get; set; }

        public virtual ICollection<Orderdetails> Orderdetails { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.Model
{
    public class OrderDetails
    {
        public int Id;
        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}

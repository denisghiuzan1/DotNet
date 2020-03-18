using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.Model
{
    public class Product
    {
        public int Id;

        public string Name { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}

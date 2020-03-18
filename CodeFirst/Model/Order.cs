using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirst.Model
{
    public partial class Order
    {
        public int OrderId { get; set; }

        public int Amount { get; set; }

        public Client Client { get; set; }

        public ICollection<OrderDetails> OrderDetails{ get; set; }
    }
}

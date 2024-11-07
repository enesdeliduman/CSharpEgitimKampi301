﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrate
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity{ get; set; }
        public decimal UnitPrice { get; set; }
        public int TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

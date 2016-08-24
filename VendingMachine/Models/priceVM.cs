using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public class priceVM
    {
        public int priceId { get; set; }
        public Nullable<int> sodaId { get; set; }
        public double price1 { get; set; }

    }
}
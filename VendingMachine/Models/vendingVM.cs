using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public class vendingVM
    {
        public int vendId { get; set; }
        public Nullable<int> sodaId { get; set; }
        public int soldqnt { get; set; }
        public double priceent { get; set; }
        public double orgprice { get; set; }
        public Nullable<int> priceId { get; set; }
        public Nullable<int> sodaQnt { get; set; }
        public System.DateTime boughttime { get; set; }

    }
}
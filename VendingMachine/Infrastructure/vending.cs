//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VendingMachine.Infrastructure
{
    using System;
    using System.Collections.Generic;
    
    public partial class vending
    {
        public int vendId { get; set; }
        public Nullable<int> sodaId { get; set; }
        public int soldqnt { get; set; }
        public double priceent { get; set; }
        public double orgprice { get; set; }
        public Nullable<int> priceId { get; set; }
        public Nullable<int> sodaQnt { get; set; }
        public System.DateTime boughttime { get; set; }
    
        public virtual price price { get; set; }
        public virtual quantity quantity { get; set; }
        public virtual soda soda { get; set; }
    }
}

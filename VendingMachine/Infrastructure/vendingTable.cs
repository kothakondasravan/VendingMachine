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
    
    public partial class vendingTable
    {
        public int vendingId { get; set; }
        public string Name { get; set; }
        public double PricePerUnit { get; set; }
        public int SoldQuantity { get; set; }
        public double PriceBought { get; set; }
        public System.DateTime BoughtTimeMain { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.Models
{
    public class quantityVM
    {
        public int qntId { get; set; }
        public Nullable<int> sodaId { get; set; }
        public Nullable<int> quantity1 { get; set; }
        public int qntCtrl { get; set; }

    }
}
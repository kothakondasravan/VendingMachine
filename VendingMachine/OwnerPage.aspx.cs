using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VendingMachine.Models;

namespace VendingMachine
{
    public partial class OwnerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdatePrice_Click(object sender, EventArgs e)
        {
            Server.Transfer("PriceUpdate.aspx");
        }

        protected void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            Server.Transfer("UpdateQuantity.aspx");
        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            Server.Transfer("ReportGeneration.aspx");
        }


    }
}
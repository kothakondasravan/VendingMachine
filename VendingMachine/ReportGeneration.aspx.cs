using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VendingMachine
{
    public partial class ReportGeneration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CalendarFrom_SelectionChanged(object sender, EventArgs e)
        {
            txtBxFrom.Text = CalendarFrom.SelectedDate.ToString("yyyy/MM/dd");
            CalendarFrom.Visible = false;
        }

        protected void CalenderTo_SelectionChanged(object sender, EventArgs e)
        {
            txtBxTo.Text = CalenderTo.SelectedDate.ToString("yyyy/MM/dd");
            CalenderTo.Visible = false;
            btnReport.Visible = true;
        }

        protected void lnkBtnFrom_Click(object sender, EventArgs e)
        {
            CalendarFrom.Visible = true;

        }

        protected void lnkBtnTo_Click(object sender, EventArgs e)
        {

            CalenderTo.Visible = true;
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            GridViewReport.Visible = true;
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Server.Transfer("OwnerPage.aspx");
        }
    }
}
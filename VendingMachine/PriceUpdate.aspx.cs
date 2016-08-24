using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VendingMachine.Infrastructure;

namespace VendingMachine
{
    public partial class PriceUpdate : System.Web.UI.Page
    {
        VendingMachineContext vc;
        public PriceUpdate()
        {
            vc = new VendingMachineContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack != true)
            {
                PopulateData();
            }

        }
        private void PopulateData(bool trycachedata = false)
        {
            GridViewPrice.DataSource = vc.prices.ToList();
            GridViewPrice.DataBind();
        }

        protected void Unnamed_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var GridPriceId = Convert.ToInt32(GridViewPrice.DataKeys[e.RowIndex].Value);


            TextBox txtBxPriceControl = (GridViewPrice.Rows[e.RowIndex]).FindControl("txtBxPrice") as TextBox;

            var price = vc.prices.Where(p => p.priceId == GridPriceId).FirstOrDefault();

            price.price1 = Convert.ToDouble(txtBxPriceControl.Text);

            vc.SaveChanges();

            GridViewPrice.EditIndex = -1;
            PopulateData();
            lblupdate.Text = "Successfully Updated";

        }

        protected void Unnamed_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewPrice.EditIndex = -1;
            PopulateData(true);
        }

        protected void Unnamed_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewPrice.EditIndex = e.NewEditIndex;
            PopulateData(true);
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("OwnerPage.aspx");
        }
    }
}
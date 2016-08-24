using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VendingMachine.Infrastructure;

namespace VendingMachine
{
    public partial class UpdateQuantity : System.Web.UI.Page
    {
        VendingMachineContext vc;
        public UpdateQuantity()
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

        private void PopulateData(bool trycache = false)
        {
            GridViewQuantity.DataSource = vc.quantities.ToList();
            GridViewQuantity.DataBind();
        }

        protected void GridViewQuantity_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewQuantity.EditIndex = e.NewEditIndex;
            PopulateData(true);
        }

        protected void GridViewQuantity_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var QuantityId = Convert.ToInt32(GridViewQuantity.DataKeys[e.RowIndex].Value);

            var txtBxQuantityControl = GridViewQuantity.Rows[e.RowIndex].FindControl("txtBxQuantity") as TextBox;

            var quantity = vc.quantities.Where(p => p.qntId == QuantityId).FirstOrDefault();

            quantity.quantity1 = Convert.ToInt32(txtBxQuantityControl.Text);

            vc.SaveChanges();
            GridViewQuantity.EditIndex = -1;
            PopulateData();


        }

        protected void GridViewQuantity_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewQuantity.EditIndex = -1;
            PopulateData(true);
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("OwnerPage.aspx");
        }
    }
}
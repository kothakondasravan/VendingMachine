using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VendingMachine.Infrastructure;
using VendingMachine.Models;

namespace VendingMachine
{
    public partial class vendingUI1 : System.Web.UI.Page
    {
        VendingBL vbl;
        VendingMachineContext vc;
        public vendingUI1()
        {
            vbl = new VendingBL();
            vc = new VendingMachineContext();

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack != true)
            {
                DropDownSoda.DataSource = vbl.GetSoda();
                DropDownSoda.DataTextField = "sodaName";
                DropDownSoda.DataValueField = "sodaId";
                DropDownSoda.DataBind();
            }

        }

        protected void DropDownSoda_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblprice.Text = Convert.ToString(vbl.getprices(Convert.ToInt32(DropDownSoda.SelectedValue)));
        }

        protected void txtboxQnty_TextChanged(object sender, EventArgs e)
        {

            //var a = Convert.ToInt32(txtboxQnty.Text);
            //var b = Convert.ToDouble(lblprice.Text);

            //var c = a * b;
            //lbltotal.Text = Convert.ToString(c);
        }

        protected void btngetsoda_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblprice.Text))
            {
                lblValidate.Text = "Please select a soda";
            }
            else if (string.IsNullOrEmpty(lbltotal.Text))
            {
                lblValidate.Text = "Please select a quantity";
            }
            else
            {
                vendingVM vm = new vendingVM();


                vm.sodaId = Convert.ToInt32(DropDownSoda.SelectedValue);
                vm.priceId = Convert.ToInt32(DropDownSoda.SelectedValue);
                vm.sodaQnt = Convert.ToInt32(DropDownSoda.SelectedValue);
                vm.orgprice = Convert.ToDouble(lblprice.Text);
                //vm.priceId =Convert.ToDouble(lblprice.Text);
                //vm.soldqnt = Convert.ToInt32(txtboxQnty.Text);
                vm.soldqnt = Convert.ToInt32(DropDownQunatity.SelectedValue);
                vm.priceent = Convert.ToDouble(lbltotal.Text);
                vm.boughttime = DateTime.Now;


                List<string> invalid = vbl.validate(vm);

                if (invalid.Count == 0)
                {

                    vbl.SodaDecrement(Convert.ToInt32(DropDownSoda.SelectedValue), vm);
                    ClearControls();
                }
                else
                {
                    label.Text = invalid[0];
                }
            }
        }
        public void ClearControls()
        {
            DropDownSoda.SelectedIndex = 0;
            lblprice.Text = string.Empty;
            //txtboxQnty.Text = string.Empty;
            DropDownQunatity.SelectedIndex = 0;
            lbltotal.Text = string.Empty;
            lblValidate.Text = string.Empty;
        }

        protected void DropDownQunatity_SelectedIndexChanged(object sender, EventArgs e)
        {

            var Sold = Convert.ToInt32(DropDownQunatity.SelectedValue);
            var Price = Convert.ToDouble(lblprice.Text);

            var SoldPrice = Sold * Price;
            lbltotal.Text = Convert.ToString(SoldPrice);
        }

        //protected void custmvalid_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    var dropdownSoda = DropDownSoda.SelectedIndex;
        //    var lblPrice = lblprice.Text;
        //    var dropdownQuantity = DropDownQunatity.SelectedIndex;
        //    if (dropdownSoda == 0 && string.IsNullOrEmpty(lblPrice) && dropdownQuantity == 0)
        //        args.IsValid = false;
        //    else
        //        args.IsValid = true;
        //}
    }
}
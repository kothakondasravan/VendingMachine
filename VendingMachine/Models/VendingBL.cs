using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachine.Infrastructure;

namespace VendingMachine.Models
{
    public class VendingBL
    {
        VendingMachineContext vc;
        vending v;
        quantity q;
        public VendingBL()
        {
            vc = new VendingMachineContext();
            v = new vending();
            q = new quantity();
        }
        public List<SodaVM> GetSoda()
        {
            var soda1 = vc.sodas.Select(p => new SodaVM { sodaId = p.sodaId, sodaName = p.sodaName }).ToList();
            return soda1;
        }

        public List<vendingVM> GetVendingDetails()
        {
            var vendingDt = vc.vendings.Select(p => new vendingVM { vendId = p.vendId, sodaId = p.sodaId, priceent = p.priceent, soldqnt = p.soldqnt, priceId = p.priceId, sodaQnt = p.sodaQnt, boughttime = p.boughttime }).ToList();
            return vendingDt;
        }

        //public List<priceVM> GetPrice()
        //{
        //    var pid = vc.prices.Select(p => new priceVM { sodaId = p.sodaId, priceId = p.priceId, price1 = p.price1 }).ToList();
        //    return pid;
        //}

        public Double getprices(int id)
        {
            var price = vc.prices.Where(p => p.sodaId == id).FirstOrDefault();
            var pm = price.price1;
            return pm;
        }

        public List<quantityVM> GetQnty()
        {
            var qnt = vc.quantities.Select(p => new quantityVM { qntId = p.qntId, sodaId = p.sodaId, quantity1 = p.quantity1, qntCtrl = p.qntCtrl }).ToList();
            return qnt;
        }

        //public int GetQnty(int id)
        //{
        //    var qnty = vc.quantities.Where(p => p.qntId == id).FirstOrDefault();
        //    var qnt = qnty.quantity1;
        //    return qnt;
        //        }


        public void Store(vendingVM vm)
        {
            vending v = new vending();
            v.sodaId = vm.sodaId;
            v.priceId = vm.priceId;
            v.sodaQnt = vm.sodaQnt;
            v.soldqnt = vm.soldqnt;
            v.orgprice = vm.orgprice;
            v.priceent = vm.priceent;
            v.boughttime = vm.boughttime;

            vc.vendings.Add(v);
            vc.SaveChanges();

            vm.vendId = v.vendId;

        }
        public List<string> validations(vendingVM val)
        {
            List<string> errors = new List<string>();
            if (val.sodaId == 0)
            {
                errors.Add("Select a Soda");
            }
            else if (string.IsNullOrEmpty(Convert.ToString(v.orgprice)))
            {
                errors.Add("Select a soda");
            }
            else if (val.soldqnt == 0)
            {
                errors.Add("Select the Quantity");
            }
            return errors;
        }
        public List<string> validate(vendingVM v)
        {
            List<string> invalid = validations(v);
            if (invalid.Count == 0)
            {
                Store(v);
            }
            return invalid;
        }
        public void SodaDecrement(int qnt, vendingVM vm)
        {
            var quant = vc.quantities.Where(p => p.qntId == qnt).FirstOrDefault();
            int quantity = Convert.ToInt32(quant.quantity1) - vm.soldqnt;
            quant.quantity1 = quantity;
            vc.SaveChanges();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROSys.WebClient.Controllers
{
    public class PaymentController : Controller
    {

        //a screen to select which table
        public ActionResult Index()
        {
            return View(Globals.Tables);
        }

        //an action to 
        public ActionResult Start(int tableNo)
        {
            var table = Globals.Tables.FirstOrDefault(t => t.Number == tableNo.ToString());
            table.StartPayment();
            return RedirectToAction("Details", new { tableNo = tableNo });
        }

        public ActionResult Details(int tableNo)
        {
            var table = Globals.Tables.FirstOrDefault(t => t.Number == tableNo.ToString());
            ViewBag.TableNo = tableNo;
            return View(table.GetDetails());
        }

        public ActionResult AddTip(int tableNo, double tip)
        {
            var table = Globals.Tables.FirstOrDefault(t => t.Number == tableNo.ToString());
            table.SetTipAmount(tip);
            return RedirectToAction("FinalDetails", new { tableNo = tableNo });
        }

        public ActionResult FinalDetails(int tableNo)
        {
            var table = Globals.Tables.FirstOrDefault(t => t.Number == tableNo.ToString());
            ViewBag.TableNo = tableNo;
            ViewBag.TipAmount = table.CurrentCustomer.currentOrder.GetTipAmount();
            return View(table.GetDetails());
        }

        public ActionResult MakePayment(int tableNo)
        {
            var table = Globals.Tables.FirstOrDefault(t => t.Number == tableNo.ToString());
            table.MakePayment();
            return RedirectToAction("Receipt", new { tableNo = tableNo });
        }

        public ActionResult Receipt(int tableNo)
        {
            var table = Globals.Tables.FirstOrDefault(t => t.Number == tableNo.ToString());
            Models.Receipt r = table.GetReceipt();
            return View(r);
        }


    }
}
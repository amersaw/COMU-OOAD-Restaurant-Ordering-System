using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROSys.WebClient.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            var x = Globals.Tables.Where(t => t.CurrentCustomer.currentOrder.Status == Models.OrderStatus.InProgress).ToList();
            return View(x);
        }


        public ActionResult MarkOrderAsReady(int tableNo)
        {
            var table = Globals.Tables.FirstOrDefault(t => t.Number == tableNo.ToString());
            table.MarkOrderAsReady();
            return RedirectToAction("Ready", new { tableNo = tableNo });
        }
        public ActionResult Ready(int tableNo)
        {
            var table = Globals.Tables.FirstOrDefault(t => t.Number == tableNo.ToString());
            return View(table.GetDetails());
        }
    }
}
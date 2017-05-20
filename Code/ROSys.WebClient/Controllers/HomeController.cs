using ROSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ROSys.WebClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int tableNo)
        {
            ViewBag.TableNo = tableNo;
            return View();
        }

        public ActionResult StartOrder(int tableNo)
        {
            var table = Globals.Tables.FirstOrDefault(t => t.Number == tableNo.ToString());

            table.StartOrder();

            List<Model.FoodDescription> ls = DBFacadeFactory.Instance.GetAll(typeof(Model.FoodDescription))
                .Select(a => (Model.FoodDescription)a)
                .ToList();
            ViewBag.TableNo = tableNo;
            return View(ls);
        }

        [HttpPost]
        public ActionResult SelectFood(int tableNo, int amount, string foodId)
        {
            var table = Globals.Tables.FirstOrDefault(t => t.Number == tableNo.ToString());

            table.SelectFood(new Guid(foodId), amount);

            List<Models.FoodLineItem> details = table.GetDetails();

            return Json(details);
        }

        public ActionResult EndOrder(int tableNo)
        {
            var table = Globals.Tables.FirstOrDefault(t => t.Number == tableNo.ToString());
            table.EndOrder();
            return RedirectToAction("OderPreview", new { tableNo = tableNo });

        }

        public ActionResult OderPreview(int tableNo)
        {

            var table = Globals.Tables.FirstOrDefault(t => t.Number == tableNo.ToString());
            ViewBag.TableNo = tableNo;
            return View(table.GetDetails());
        }


        public ActionResult SubmitOrder(int tableNo)
        {
            var table = Globals.Tables.FirstOrDefault(t => t.Number == tableNo.ToString());
            table.SubmitOrder();
            return RedirectToAction("Index", new { tableNo = tableNo });
//            return RedirectToAction("OderPreview", new { tableNo = tableNo });

        }

    }
}
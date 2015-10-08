using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oncloud.Web.oddBase.Models;
using oncloud.Web.oddBase.Models.Home;

namespace oncloud.Web.oddBase.Controllers
{
    public class HomeController : Controller
    {
        EntitiesOddAdbase db=new EntitiesOddAdbase();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Table()
        {
            Table data=new Table();
            data.Setinitialization(db);
            return View(data.GetDataModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public ActionResult FindStreets(string term)
        //{
        //    var streets = from m in db.IntelliSenseStreet where m.Street.Contains(term) select m;
        //    var projection = from street in streets
        //                     select new
        //                     {
        //                         id = street.id,
        //                         label = street.Street + " " + street.Type,
        //                         value = street.Street + " " + street.Type
        //                     };
        //    return Json(projection.ToList(), JsonRequestBehavior.AllowGet);
        //}
    }
}
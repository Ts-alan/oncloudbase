using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oncloud.Web.oddBase.Controllers
{
    [Authorize(Roles="admin")]
    public class АdministrationController : Controller
    {
        // GET: Аdministration
        public ActionResult Index()
        {
            return View();
        }
    }
}
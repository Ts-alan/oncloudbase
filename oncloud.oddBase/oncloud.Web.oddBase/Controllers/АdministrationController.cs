using Microsoft.AspNet.Identity.EntityFramework;
using oncloud.Web.oddBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity.Owin;

namespace oncloud.Web.oddBase.Controllers
{
    [Authorize(Roles = "admin, OrganizationAdmin")]
    public partial class АdministrationController : Controller
    {

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        // GET: Аdministration
        public virtual ActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles = "Admin, OrganizationAdmin")]
        public virtual ActionResult Users()
        {
            var users = UserManager.Users;
            return View(users);
        }
    }
}
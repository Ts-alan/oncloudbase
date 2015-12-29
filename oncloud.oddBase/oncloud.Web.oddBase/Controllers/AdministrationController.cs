using Microsoft.AspNet.Identity.EntityFramework;
using oncloud.Web.oddBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace oncloud.Web.oddBase.Controllers
{
	[Authorize]
	public partial class AdministrationController : Controller
	{

		private ApplicationUserManager UserManager
		{
			get
			{
				return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
		}
        public RoleManager<IdentityRole> RoleManager
        {
            get
            {
                return  HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
 
        }

        // GET: Аdministration
        public virtual ActionResult Index()
		{
			return View();
		}

       
        public virtual async Task<ActionResult> Users()
		{
			ViewBag.users = UserManager.Users.ToList();
           
            return View();
		}

		//public virtual async Task<ActionResult> LockUser(string userId)
		//{
		//	await UserManager.SetLockoutEndDateAsync(userId, DateTime.Now.AddDays(1));
		//	//await UserManager.SetLockoutEnabledAsync(userId, true);
		//	return RedirectToAction(MVC.Administration.Users());
		//}

		//public virtual async Task<ActionResult> UnLockUser(string userId)
		//{
		//	await UserManager.SetLockoutEndDateAsync(userId, DateTimeOffset.Now);
		//	//await UserManager.SetLockoutEnabledAsync(userId, false);
		//	return RedirectToAction(MVC.Administration.Users());
		//}
	}
}
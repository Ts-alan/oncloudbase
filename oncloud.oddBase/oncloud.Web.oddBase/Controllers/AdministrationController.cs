using Microsoft.AspNet.Identity.EntityFramework;
using oncloud.Web.oddBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace oncloud.Web.oddBase.Controllers
{
	[Authorize(Roles = "admin, OrganizationAdmin")]
	public partial class AdministrationController : Controller
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
		public virtual async Task<ActionResult> Users()
		{
			var users = UserManager.Users.ToList();
			if (!User.IsInRole("admin"))
			{
				var model = new List<ApplicationUser>();

				foreach (var user in users)
				{
					var userRoles = await UserManager.GetRolesAsync(user.Id);
					if (!userRoles.Contains("admin"))
					{
						model.Add(user);
					}
				}
				users = model;
			}
			//users.Where(a=>a.)
			return View(users);
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
﻿using oncloud.Domain.Concrete;
using oncloud.Web.oddBase.Infrastructure;
using oncloud.Web.oddBase.Migrations;
using oncloud.Web.oddBase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace oncloud.Web.oddBase
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, IdentityContextMigrations.Configuration>());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDbContext, Configuration>());

            //Database.SetInitializer<EFDbContext>(new DropCreateDatabaseIfModelChanges<EFDbContext>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
           

        }
    }
}

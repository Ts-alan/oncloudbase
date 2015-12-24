namespace oncloud.Web.oddBase.IdentityContextMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using oncloud.Web.oddBase.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<oncloud.Web.oddBase.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"IdentityContextMigrations";
        }

        protected override void Seed(oncloud.Web.oddBase.Models.ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "SetMembers" };
            var role3 = new IdentityRole { Name = "EditData" };
            var role4 = new IdentityRole { Name = "Review" };
            
            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);
            roleManager.Create(role4);
            
            // создаем пользователей
            var admin = new ApplicationUser { Email = "testadmin@mail.ru", UserName = "testadmin@mail.ru" };
            string password = "tester";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
               
            }

            base.Seed(context);
        }
    }
}

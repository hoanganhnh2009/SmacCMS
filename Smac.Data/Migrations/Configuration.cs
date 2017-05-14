namespace TedShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Smac.Data;
    using Smac.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Smac.Data.SmacDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        //protected override void Seed(Smac.Data.SmacDbContext context)
        //{
        //    //  This method will be called after migrating to the latest version.

        //    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new SmacDbContext()));

        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new SmacDbContext()));

        //    var user = new ApplicationUser()
        //    {
        //        UserName = "hoanganhnh2009",
        //        Email = "hoanganhnh2009@gmail.com",
        //        EmailConfirmed = true,
        //        BirthDay = DateTime.Now,
        //        FullName = "Nguyễn Hữu Thành"

        //    };

        //    manager.Create(user, "123456");

        //    if (!roleManager.Roles.Any())
        //    {
        //        roleManager.Create(new IdentityRole { Name = "Admin" });
        //        roleManager.Create(new IdentityRole { Name = "User" });
        //    }

        //    var adminUser = manager.FindByEmail("tedu.international@gmail.com");

        //    manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });

        //}

        private void CreateProductCategorySample(SmacDbContext context) {
            List<ProductCategory> listProductCategory = new List<ProductCategory>();

        }

        //  This method will be called after migrating to the latest version.

        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data. E.g.
        //
        //    context.People.AddOrUpdate(
        //      p => p.FullName,
        //      new Person { FullName = "Andrew Peters" },
        //      new Person { FullName = "Brice Lambson" },
        //      new Person { FullName = "Rowan Miller" }
        //    );
        //
    }
}

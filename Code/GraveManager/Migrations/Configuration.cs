namespace GraveManager.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using GraveManager.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<GraveManager.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        bool AddUserAndRole(GraveManager.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user1@glasnevintrust.ie",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }

        protected override void Seed(GraveManager.Models.ApplicationDbContext context)
        {
            AddUserAndRole(context);

            context.Graves.AddOrUpdate(g => g.Cemetery,
                new Grave
                {
                    Cemetery = "Glasnevin Cemetery",
                    RowID = "AA",
                    GraveNumber = 23,
                    Name = "Daniel O'Connell",
                    Gender = GenderType.Male,
                    Address = "Merrion Square",
                    DOB = new DateTime(1775, 08, 06),
                    DOD = new DateTime(1847, 05, 15),
                    InGrave = "None",
                    Longitude = 53.3699538,
                    Latitude = -6.2771961
                },
                new Grave
                {
                    Cemetery = "Glasnevin Cemetery",
                    RowID = "GD",
                    GraveNumber = 82,
                    Name = "Mícheál Ó Coileáin (Michael Collins)",
                    Gender = GenderType.Male,
                    Address = "Portobello Barracks, Co. Dublin",
                    DOB = new DateTime(1890, 10, 16),
                    DOD = new DateTime(1922, 08, 22),
                    InGrave = "None",
                    Longitude = 53.369512,
                    Latitude = -6.276536
                },
                new Grave
                {
                    Cemetery = "Glasnevin Cemetery",
                    RowID = "ZE",
                    GraveNumber = 22,
                    Name = "Arthur Griffith",
                    Gender = GenderType.Male,
                    Address = "122, St. Laurence Road, Dublin",
                    DOB = new DateTime(1872, 03, 31),
                    DOD = new DateTime(1922, 08, 12),
                    InGrave = "Maud Sheehan, Nevin Griffith and Ita Griffith",
                    Longitude = 53.371042,
                    Latitude = -6.2775053
                },
                new Grave
                {
                    Cemetery = "Glasnevin Cemetery",
                    RowID = "ZE",
                    GraveNumber = 26,
                    Name = "Joe Bloggs",
                    Gender = GenderType.Male,
                    Address = "123 Malahide Road, Dublin",
                    DOB = new DateTime(1872, 03, 31),
                    DOD = new DateTime(1920, 06, 12),
                    InGrave = "Mary Feeney",
                    Longitude = 53.371142,
                    Latitude = -6.2785053
                });
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
}

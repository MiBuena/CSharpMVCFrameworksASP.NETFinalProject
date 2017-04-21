using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeisureTimeSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LeisureTimeSystem.Data.LeisureSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "LeisureTimeSystem.Data.LeisureSystemContext";
        }

        protected override void Seed(LeisureTimeSystem.Data.LeisureSystemContext context)
        {
            AddRoles(context);
        }

        private static void AddRoles(LeisureSystemContext context)
        {
            if (!context.Roles.Any(x => x.Name == "BeginnerUser"))
            {
                var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

                roleManager.Create(new IdentityRole("BeginnerUser"));
            }

            if (!context.Roles.Any(x => x.Name == "ClientUser"))
            {
                var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

                roleManager.Create(new IdentityRole("ClientUser"));
            }


            if (!context.Roles.Any(x => x.Name == "OrganizationRepresentative"))
            {
                var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

                roleManager.Create(new IdentityRole("OrganizationRepresentative"));
            }

            if (!context.Roles.Any(x => x.Name == "BlogAuthor"))
            {
                var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

                roleManager.Create(new IdentityRole("BlogAuthor"));
            }


            if (!context.Roles.Any(x => x.Name == "Administrator"))
            {
                var roleManager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

                roleManager.Create(new IdentityRole("Administrator"));
            }


        }


    }
}

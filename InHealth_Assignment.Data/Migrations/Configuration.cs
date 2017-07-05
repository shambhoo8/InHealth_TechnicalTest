using InHealth_Assignment.Data.DBContext;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace InHealth_Assignment.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<InHealth_AssignmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<InHealth_AssignmentContext>());
        }

        protected override void Seed(InHealth_AssignmentContext context)
        {
            GenerateUserRoles(context);
            context.SaveChanges();
        }
        private static void GenerateUserRoles(InHealth_AssignmentContext context)
        {
            context.UserRoles.Add(new Model.Entities.UserRole { RoleName = "Admin", Description = "Admin User", IsActive=true });
            context.UserRoles.Add(new Model.Entities.UserRole { RoleName = "Standard User", Description = "Standard User", IsActive=true });
        }
    }
}
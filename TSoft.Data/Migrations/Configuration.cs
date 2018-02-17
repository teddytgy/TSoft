namespace TSoft.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<TSoftContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TSoftContext context)
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("TSoftContext", "UserProfile", "UserId", "UserName", false);
            }

            if (!Roles.RoleExists("Administrator"))
                Roles.CreateRole("Administrator");

            if (!Roles.RoleExists("Member"))
                Roles.CreateRole("Member");

            if (!Roles.RoleExists("Silver Member"))
                Roles.CreateRole("Silver Member");

            if (!Roles.RoleExists("Gold Member"))
                Roles.CreateRole("Gold Member");

            for (int i = 0; i < 1000; i++)
            {
                string userName = "teddytgy" + i;
                if (!WebSecurity.UserExists(userName))
                    WebSecurity.CreateUserAndAccount(
                        userName,
                        "password",
                        new
                        {
                            FirstName = "Theodros" + i,
                            LastName = "Gebreyesus" + i,
                            Email = "teddytgy" + i + "@gmail.com",
                            Phone = "703-944-6417"
                        });

                if (!Roles.GetRolesForUser(userName).Contains("Administrator"))
                    Roles.AddUsersToRoles(new[] { userName }, new[] { "Administrator" });

                userName = "lilytekle" + i;

                if (!WebSecurity.UserExists(userName))
                    WebSecurity.CreateUserAndAccount(
                        userName,
                        "password",
                        new
                        {
                            FirstName = "Lidia" + i,
                            LastName = "Tekle" + i,
                            Email = "lilytekle" + i + "@yahoo.com",
                            Phone = "202-352-9963"
                        });

                if (!Roles.GetRolesForUser(userName).Contains("Gold Member"))
                    Roles.AddUsersToRoles(new[] { userName }, new[] { "Gold Member" });
            }
        }
    }
}

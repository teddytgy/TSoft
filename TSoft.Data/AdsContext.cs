using System.Data.Entity;
using TSoft.Data.Mappings;
using Ted.UM.Data.Configuration;
using TSoft.Data.Common.Logging;
using log4net.Repository.Hierarchy;

namespace TSoft.Data
{
    public class TSoftContext : DbContext
    {
        static TSoftContext()
        {
            Database.SetInitializer<TSoftContext>(null);
        }

        public TSoftContext()
            : base("Name=TSoftContext")
        {
            
        }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MembershipConfig());
            modelBuilder.Configurations.Add(new OAuthMembershipConfig());
            modelBuilder.Configurations.Add(new PersonConfig());
            modelBuilder.Configurations.Add(new RoleConfig());
            modelBuilder.Configurations.Add(new UserProfileConfig());
            modelBuilder.Configurations.Add(new Log4Net_ErrorConfig());
        }
    }
}

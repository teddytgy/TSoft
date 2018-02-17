using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TSoft.Entities.Models;

namespace TSoft.Data.Mappings
{   
    public class UserProfileConfig : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileConfig()
        {
            HasKey(up => up.UserId);
            Property(up => up.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(up => up.UserName).HasColumnName("UserName").HasColumnType("nvarchar").HasMaxLength(128).IsOptional();

            this.HasMany(up => up.Roles)
               .WithMany(r => r.UserProfiles)
               .Map(usersinroles =>
               {
                   usersinroles.MapLeftKey("UserId");
                   usersinroles.MapRightKey("RoleId");
                   usersinroles.ToTable("webpages_UsersInRoles");
               });

            ToTable("UserProfile");
            
            // Relationships
            //this.HasRequired(p => p.Person)
            //    .WithRequiredPrincipal();
        }       
    }
}

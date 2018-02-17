using System.Data.Entity.ModelConfiguration;
using TSoft.Entities.Models;

namespace TSoft.Data.Mappings
{  
    public class RoleConfig : EntityTypeConfiguration<Role>
    {
        public RoleConfig()
        {
            HasKey(r => r.RoleId);
            Property(r => r.RoleId).HasColumnName("RoleId").HasColumnType("int").IsRequired();
            Property(r => r.RoleName).HasColumnName("RoleName").HasColumnType("nvarchar").HasMaxLength(256).IsRequired();

            ToTable("webpages_Roles");
        }       
    }
}

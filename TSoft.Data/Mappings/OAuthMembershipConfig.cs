using System.Data.Entity.ModelConfiguration;
using TSoft.Entities.Models;

namespace TSoft.Data.Mappings
{
    public class OAuthMembershipConfig : EntityTypeConfiguration<OAuthMembership>
    {
        public OAuthMembershipConfig()
        {
            HasKey(o => new { o.Provider, o.ProviderUserId });
            Property(o => o.Provider).HasColumnName("Provider").HasColumnType("nvarchar").HasMaxLength(30).IsRequired();
            Property(o => o.ProviderUserId).HasColumnName("ProviderUserId").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            Property(o => o.UserId).HasColumnName("UserId").HasColumnType("int").IsRequired();

            ToTable("webpages_OAuthMembership");
        }        
    }
}

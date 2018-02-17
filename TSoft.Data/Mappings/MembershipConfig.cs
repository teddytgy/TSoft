using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TSoft.Entities.Models;

namespace Ted.UM.Data.Configuration
{    
    public class MembershipConfig : EntityTypeConfiguration<Membership>
    {
        public MembershipConfig()
        {
            HasKey(m => m.UserId);
            Property(m => m.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(m => m.ConfirmationToken).HasColumnName("ConfirmationToken").HasColumnType("nvarchar").HasMaxLength(128);
            Property(m => m.IsConfirmed).HasColumnName("IsConfirmed").HasColumnType("bit").IsOptional();
            Property(m => m.LastPasswordFailureDate).HasColumnName("LastPasswordFailureDate").HasColumnType("datetime").IsOptional();
            Property(m => m.PasswordFailuresSinceLastSuccess).HasColumnName("PasswordFailuresSinceLastSuccess").HasColumnType("int").IsRequired();
            Property(m => m.Password).HasColumnName("Password").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            Property(m => m.PasswordChangedDate).HasColumnName("PasswordChangedDate").HasColumnType("datetime").IsOptional();
            Property(m => m.PasswordSalt).HasColumnName("PasswordSalt").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            Property(m => m.PasswordVerificationToken).HasColumnName("PasswordVerificationToken").HasColumnType("nvarchar").HasMaxLength(128);
            Property(m => m.PasswordVerificationTokenExpirationDate).HasColumnName("PasswordVerificationTokenExpirationDate").HasColumnType("datetime").IsOptional();

            ToTable("webpages_Membership");
        }       
    }
}

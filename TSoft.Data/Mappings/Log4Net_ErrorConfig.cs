using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TSoft.Entities.Models;

namespace TSoft.Data.Mappings
{
    public class Log4Net_ErrorConfig : EntityTypeConfiguration<Log4Net_Error>
    {
        public Log4Net_ErrorConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Date).HasColumnName("Date").HasColumnType("datetime").IsRequired();
            Property(p => p.Thread).HasColumnName("Thread").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            Property(p => p.Level).HasColumnName("Level").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            Property(p => p.Logger).HasColumnName("Logger").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            Property(p => p.Message).HasColumnName("Message").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();

            //this.HasRequired(u => u.UserProfile)
            //    .WithRequiredDependent();
        }
    }
}

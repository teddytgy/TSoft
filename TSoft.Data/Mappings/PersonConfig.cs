using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TSoft.Entities.Models;

namespace TSoft.Data.Mappings
{    
    public class PersonConfig : EntityTypeConfiguration<Person>
    {
        public PersonConfig()
        {
            HasKey(p => p.PersonId);

            Property(p => p.PersonId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.FirstName).HasColumnName("FirstName").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            Property(p => p.LastName).HasColumnName("LastName").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            Property(p => p.Email).HasColumnName("Email").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            Property(p => p.Phone).HasColumnName("Phone").HasColumnType("nvarchar").HasMaxLength(128).IsRequired();

            //this.HasRequired(u => u.UserProfile)
            //    .WithRequiredDependent();
        }
    }
}

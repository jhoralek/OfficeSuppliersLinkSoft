using OfficeSuppliersLinkSoft.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OfficeSuppliersLinkSoft.Data.Configuration
{
    /// <summary>
    /// Fluent API configuration of Groups table
    /// </summary>
    public class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupConfiguration()
        {
            ToTable("Groups");
            Property(g => g.GroupId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(g => g.Name).IsRequired().HasMaxLength(50);            
        }
    }
}

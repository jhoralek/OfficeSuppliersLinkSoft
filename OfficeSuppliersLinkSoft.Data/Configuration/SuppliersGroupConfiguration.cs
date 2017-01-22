using OfficeSuppliersLinkSoft.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OfficeSuppliersLinkSoft.Data.Configuration
{
    public class SuppliersGroupConfiguration : EntityTypeConfiguration<SuppliersGroup>
    {
        public SuppliersGroupConfiguration()
        {
            ToTable("SupplierGroups");
            Property(sg => sg.SuppliersGroupId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(sg => sg.GroupId).IsRequired();
            Property(sg => sg.SupplierId).IsRequired();
        }
    }
}

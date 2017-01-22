using OfficeSuppliersLinkSoft.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace OfficeSuppliersLinkSoft.Data.Configuration
{
    public class SupplierConfiguration : EntityTypeConfiguration<Supplier>
    {
        public SupplierConfiguration()
        {
            ToTable("Suppliers");
            Property(s => s.SupplierId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(s => s.Name).IsRequired().HasMaxLength(100);
            Property(s => s.Address).IsRequired().HasMaxLength(150);
            Property(s => s.EmailAddress).IsRequired().HasMaxLength(150);
            Property(s => s.Telephone).IsRequired();
        }
    }
}

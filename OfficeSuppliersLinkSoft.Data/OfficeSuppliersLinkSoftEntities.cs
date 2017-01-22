using OfficeSuppliersLinkSoft.Data.Configuration;
using OfficeSuppliersLinkSoft.Model;
using System.Data.Entity;

namespace OfficeSuppliersLinkSoft.Data
{
    public class OfficeSuppliersLinkSoftEntities : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SuppliersGroup> SuppliersGroups { get; set; }

        public virtual void Commit() => base.SaveChanges();

        /// <summary>
        /// DB context constructor
        /// </summary>
        public OfficeSuppliersLinkSoftEntities() : base ("OfficeSuppliersEntities") { }

        /// <summary>
        /// Configure database tables
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new SupplierConfiguration());
            modelBuilder.Configurations.Add(new SuppliersGroupConfiguration());
        }
    }
}

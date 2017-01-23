using OfficeSuppliersLinkSoft.Data.Configuration;
using OfficeSuppliersLinkSoft.Model;
using System.Data.Entity;

namespace OfficeSuppliersLinkSoft.Data
{
    /// <summary>
    /// Db context of EF 6.1.3 with latest patterns like Unit Of Work and 
    /// Repository pattern
    /// </summary>
    public class OfficeSuppliersLinkSoftEntities : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public virtual void Commit() => base.SaveChanges();

        /// <summary>
        /// DB context constructor
        /// </summary>
        public OfficeSuppliersLinkSoftEntities() : base("OfficeSuppliersEntities") { }

        /// <summary>
        /// Configure database tables
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // !!!!!!!!!!
            // Important this two configuration clases do the many to many relationship
            // between table groups and suppliers automaticaly
            // It is not neccessary do this on your own
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new SupplierConfiguration());
        }
    }
}

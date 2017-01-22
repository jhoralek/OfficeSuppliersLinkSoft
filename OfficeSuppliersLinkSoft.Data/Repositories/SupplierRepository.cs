using OfficeSuppliersLinkSoft.Data.Infrastructure;
using OfficeSuppliersLinkSoft.Model;

namespace OfficeSuppliersLinkSoft.Data.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier> { }
    public class SupplierRepository : RepositoryBase<Supplier>, ISupplierRepository
    {
        /// <summary>
        /// Setup of repository instance with DB factory
        /// </summary>
        /// <param name="dbFactory">Initialize DB context</param>
        public SupplierRepository(IDbFactory dbFactory) : base(dbFactory) {}
    }
}

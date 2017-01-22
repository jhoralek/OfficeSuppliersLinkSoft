using OfficeSuppliersLinkSoft.Data.Infrastructure;
using OfficeSuppliersLinkSoft.Model;

namespace OfficeSuppliersLinkSoft.Data.Repositories
{
    public interface ISuppliersGroupRepository : IRepository<SuppliersGroup> { }
    public class SuppliersGroupRepository : RepositoryBase<SuppliersGroup>, ISuppliersGroupRepository
    {
        /// <summary>
        /// Setup of repository instance with DB factory
        /// </summary>
        /// <param name="dbFactory">Initialize DB context</param>
        public SuppliersGroupRepository(IDbFactory dbFactory) : base(dbFactory) {}
    }
}

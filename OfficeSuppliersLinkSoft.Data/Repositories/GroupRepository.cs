using OfficeSuppliersLinkSoft.Data.Infrastructure;
using OfficeSuppliersLinkSoft.Model;

namespace OfficeSuppliersLinkSoft.Data.Repositories
{
    /// <summary>
    /// Interface IGroupRepository derived CRUD method form IRepository<T>
    /// And can implement his own methods
    /// </summary>
    public interface IGroupRepository : IRepository<Group> { }

    /// <summary>
    /// Group repo.
    /// Through this class will flow every DB command from the service
    /// layer
    /// </summary>
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        /// <summary>
        /// Setup of repository instance with DB factory
        /// </summary>
        /// <param name="dbFactory">Initialize DB context</param>
        public GroupRepository(IDbFactory dbFactory) : base(dbFactory) {}

    }
}

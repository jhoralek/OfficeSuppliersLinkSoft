using OfficeSuppliersLinkSoft.Data.Infrastructure;
using OfficeSuppliersLinkSoft.Data.Repositories;
using OfficeSuppliersLinkSoft.Model;
using System.Collections.Generic;

namespace OfficeSuppliersLinkSoft.Service
{
    public interface IGroupService
    {
        IEnumerable<Group> GetGroups();
        Group GetGroup(int groupId);
        void CreateGroup(Group group);
        void UpdateGroup(Group group);
        void RemoveGroup(Group group);
        void SaveGroup();
        void Dispose();
    }

    /// <summary>
    /// Service of GroupService
    /// This is the only layer where business logic
    /// should be. This service will be interacting with
    /// Controllers in presentation layer.
    /// 
    /// We use IGroupService interface as a guide for all
    /// neccessary functions
    /// </summary>
    public class GroupService : IGroupService
    {
        /// <summary>
        /// We use this interface for access to the Group's repo.
        /// </summary>
        IGroupRepository _groupRepository;        

        /// <summary>
        /// Execute DB commands
        /// </summary>
        IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initialize new instance of Group service with neccessary repositories injected into this object
        /// </summary>
        /// <param name="groupRepository">Group's repository</param>
        /// <param name="unitOfWork">Unit of work instance for data command execution</param>
        public GroupService(IGroupRepository groupRepository, IUnitOfWork unitOfWork)
        {
            this._groupRepository = groupRepository;
            this._unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Create new group
        /// </summary>
        /// <param name="group">Group object</param>
        public void CreateGroup(Group group) => _groupRepository.Add(group);

        /// <summary>
        /// Get the group by its ID
        /// </summary>
        /// <param name="groupId">Group ID</param>
        /// <returns></returns>
        public Group GetGroup(int groupId) => _groupRepository.GetById(groupId);

        /// <summary>
        /// Method obtains every group in repository
        /// </summary>
        /// <returns>List of groups</returns>
        public IEnumerable<Group> GetGroups() => _groupRepository.GetAll();        

        /// <summary>
        /// Mark group as remove
        /// </summary>
        /// <param name="group">Instance of group object</param>
        public void RemoveGroup(Group group) => _groupRepository.Delete(group);

        /// <summary>
        /// Mark group as updated
        /// </summary>
        /// <param name="group">Instance of group object</param>
        public void UpdateGroup(Group group) => _groupRepository.Update(group);

        /// <summary>
        /// Execute all commands which has been done before
        /// call this method
        /// </summary>
        public void SaveGroup() => _unitOfWork.Commit();

        /// <summary>
        /// Dispose db context
        /// </summary>
        public void Dispose() => _unitOfWork.Dispose();
    }
}

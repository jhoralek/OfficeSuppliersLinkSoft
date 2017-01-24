
namespace OfficeSuppliersLinkSoft.Web.Models
{
    /// <summary>
    /// Class is used for asigning and deasigning 
    /// groups for each supplier
    /// </summary>
    public class AssignedGroupsViewModel
    {
        /// <summary>
        /// Group ID
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Is group assigned or not
        /// </summary>
        public bool Assigned { get; set; }
    }
}
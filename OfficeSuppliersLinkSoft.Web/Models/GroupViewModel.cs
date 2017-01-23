
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfficeSuppliersLinkSoft.Web.Models
{
    /// <summary>
    /// We do need to define Key, Requirements and other
    /// suff right here for controller scaffolding
    /// </summary>
    public class GroupViewModel
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int GroupId { get; set; }

        /// <summary>
        /// Group's name 
        /// Is required. Min. length is 3 characters. Max. length is 30 characters.
        /// </summary>
        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Group's name is required!")]
        [MaxLength(50, ErrorMessage = "Max. group's name length is 50 characters!")]
        public string Name { get; set; }

        /// <summary>
        /// Supplier groups collection
        /// </summary>
        public virtual ICollection<SupplierViewModel> SuppliersGroups { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfficeSuppliersLinkSoft.Web.Models
{
    public class GroupViewModel
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Group's name 
        /// Is required. Min. length is 3 characters. Max. length is 30 characters.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Supplier groups collection
        /// </summary>
        public virtual ICollection<SupplierViewModel> SuppliersGroups { get; set; }
    }
}
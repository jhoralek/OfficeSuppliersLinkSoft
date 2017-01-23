using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfficeSuppliersLinkSoft.Model
{
    /// <summary>
    /// Supplier class
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Initialize list or groups 
        /// </summary>
        public Supplier()
        {
            Groups = new HashSet<Group>();
        }
        /// <summary>
        /// Primary key
        /// </summary>
        public int SupplierId { get; set; }
        /// <summary>
        /// Supplier's name
        /// Is required
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required!")]
        [MaxLength(50, ErrorMessage = "Maximal length is 50 characters!")]
        public string Name { get; set; }

        /// <summary>
        /// Supplier's address
        /// Is required
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Supplier's email address
        /// Is required and must be valid email address
        /// </summary>        
        public string EmailAddress { get; set; }

        /// <summary>
        /// Supplier's phone number
        /// Is required and must be valid nine digit number without any space
        /// </summary>
        public int Telephone { get; set; }

        /// <summary>
        /// Supplier's groups collection
        /// </summary>        
        public virtual ICollection<Group> Groups { get; set; }
    }
}

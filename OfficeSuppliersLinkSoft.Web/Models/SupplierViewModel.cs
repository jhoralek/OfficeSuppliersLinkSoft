using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfficeSuppliersLinkSoft.Web.Models
{
    /// <summary>
    /// We do need to define Key, Requirements and other
    /// suff right here for controller scaffolding
    /// </summary>
    public class SupplierViewModel
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public int SupplierId { get; set; }
        /// <summary>
        /// Supplier's name
        /// Is required
        /// </summary>
        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Supplier's name is required!")]
        [MaxLength(50, ErrorMessage = "Max. supplier's name length is 50 characters!")]
        public string Name { get; set; }

        /// <summary>
        /// Supplier's address
        /// Is required
        /// </summary>
        [Display(Name = "Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Supplier's address is required!")]
        [MaxLength(150, ErrorMessage = "Max. supplier's address length is 150 characters!")]
        public string Address { get; set; }

        /// <summary>
        /// Supplier's email address
        /// Is required and must be valid email address
        /// </summary>
        [Display(Name = "Email address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Supplier's email address is required!")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address!")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Supplier's phone number
        /// Is required and must be valid nine digit number without any space
        /// </summary>
        [Display(Name = "Phone number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Supplier's phone number is required!")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Supplier's phone number should by nine digit number with no spaces!")]
        public int Telephone { get; set; }

        /// <summary>
        /// Supplier's groups collection
        /// </summary>        
        public virtual ICollection<GroupViewModel> Groups { get; set; }
    }
}
﻿using System.Collections.Generic;

namespace OfficeSuppliersLinkSoft.Model
{
    /// <summary>
    /// Supplier class
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int SupplierId { get; set; }
        /// <summary>
        /// Supplier's name
        /// Is required
        /// </summary>
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
        public virtual ICollection<Group> SuppliersGroups { get; set; }
    }
}

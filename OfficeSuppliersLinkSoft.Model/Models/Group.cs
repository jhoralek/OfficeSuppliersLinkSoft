﻿using System.Collections.Generic;

namespace OfficeSuppliersLinkSoft.Model
{
    /// <summary>
    /// Group class
    /// </summary>
    public class Group
    {

        /// <summary>
        /// Initialize collection of suppliers
        /// </summary>
        public Group()
        {
            Suppliers = new HashSet<Supplier>();
        }
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
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}

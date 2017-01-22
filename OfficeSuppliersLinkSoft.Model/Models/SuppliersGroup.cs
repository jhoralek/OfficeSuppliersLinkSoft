namespace OfficeSuppliersLinkSoft.Model
{ 
    /// <summary>
    /// Supplier's group class
    /// </summary>
    public class SuppliersGroup
    {
        /// <summary>
        /// Primary key
        /// </summary>      
        public int SuppliersGroupId { get; set; }
        /// <summary>
        /// Foreign key from Group object
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Foreign kez from Supplier object
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Intance of group's object
        /// </summary>
        public virtual Group Group { get; set; }

        /// <summary>
        /// Instance of supplier's object
        /// </summary>
        public virtual Supplier Supplier {get; set; }
    }
}

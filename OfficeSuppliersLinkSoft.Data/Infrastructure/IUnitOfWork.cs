namespace OfficeSuppliersLinkSoft.Data.Infrastructure
{
    /// <summary>
    /// Interface for pattern UnitOfWork
    /// 
    /// It implements one method Commit which will be used in service
    /// layer
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Do the database work
        /// </summary>
        void Commit();
        /// <summary>
        /// Dispose db context
        /// </summary>
        void Dispose();
    }
}

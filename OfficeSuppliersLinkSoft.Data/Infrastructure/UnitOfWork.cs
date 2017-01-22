using System;

namespace OfficeSuppliersLinkSoft.Data.Infrastructure
{
    /// <summary>
    /// Class will be use for executing database commands in 
    /// service layer
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// DB factory interface instance
        /// </summary>
        readonly IDbFactory _dbFactory;

        /// <summary>
        /// DB context instance
        /// </summary>
        OfficeSuppliersLinkSoftEntities _dbContext;

        /// <summary>
        /// Initialize object of UnitOfWork with IDbFactory 
        /// param
        /// </summary>
        /// <param name="dbFactory">DB factory</param>
        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }

        /// <summary>
        /// Get the instance of the context
        /// </summary>
        public OfficeSuppliersLinkSoftEntities DbContext =>  _dbContext ?? (_dbContext = _dbFactory.Init());

        /// <summary>
        /// Send command action to the database
        /// </summary>
        public void Commit() => DbContext.Commit();
    }
}

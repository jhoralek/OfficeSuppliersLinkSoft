using System;

namespace OfficeSuppliersLinkSoft.Data.Infrastructure
{
    /// <summary>
    /// Ensure when Implements IDbFacotory then IDisposable 
    /// will be implemented as well
    /// </summary>
    public interface IDbFactory : IDisposable
    {
        /// <summary>
        /// Initialization of entities
        /// </summary>
        /// <returns></returns>
        OfficeSuppliersLinkSoftEntities Init();
    }
}

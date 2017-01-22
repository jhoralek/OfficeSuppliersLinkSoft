using System;

namespace OfficeSuppliersLinkSoft.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        OfficeSuppliersLinkSoftEntities _context;
        /// <summary>
        /// Init db context when is null or return initialized one
        /// </summary>
        /// <returns></returns>
        public OfficeSuppliersLinkSoftEntities Init()
        {
            return _context ?? (_context = new OfficeSuppliersLinkSoftEntities());
        }

        /// <summary>
        /// Dispose DB context
        /// </summary>
        protected override void DisposeCore()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}

using System;

namespace OfficeSuppliersLinkSoft.Data.Infrastructure
{
    /// <summary>
    /// Disposing implemented objects
    /// </summary>
    public class Disposable : IDisposable
    {
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        /// <summary>
        /// Override this method to dispose 
        /// custom object
        /// Use for disposing object your way
        /// </summary>
        protected virtual void DisposeCore()
        {
        }
    }
}

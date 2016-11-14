using System;
using System.Collections.Generic;

namespace BaseSource.Data.Infrastructure
{
    public class DisposableObject : IDisposable
    {
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DisposableObject()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed || !disposing) return;

            _isDisposed = true;

            DisposeCore();
        }

        protected virtual void DisposeCore()
        {
            foreach (var disposable in Disposables)
            {
                disposable?.Dispose();
            }

            Disposables.Clear();
            Disposables = null;
        }

        protected T CreateObject<T>(Func<T> createObject) where T : IDisposable
        {
            var result = createObject();
            Manage(result);
            return result;
        }

        protected void Manage(IDisposable disposable)
        {
            if (disposable != null) Disposables.Add(disposable);
        }

        protected void Manage(IEnumerable<IDisposable> disposables)
        {
            foreach (var disposable in disposables)
            {
                Manage(disposable);
            }
        }

        protected IList<IDisposable> Disposables { get; set; } = new List<IDisposable>();

        private bool _isDisposed;
    }
}

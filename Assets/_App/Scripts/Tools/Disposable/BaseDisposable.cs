using System;
using UniRx;

namespace Tools.Disposable
{
    public class BaseDisposable : IDisposable
    {
        private CompositeDisposable _disposable;

        protected void AddDisposable(IDisposable disposable)
        {
            _disposable ??= new CompositeDisposable();
            _disposable.Add(disposable);
        }

        protected CompositeDisposable GetDisposable()
        {
            _disposable ??= new CompositeDisposable();
            return _disposable;
        }
        
        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}
using Tools.Disposable;
using UniRx;

namespace Game.Popups
{
    public abstract class PopupFactory : BaseDisposable
    {
        public abstract Popup Create(CompositeDisposable disposer);
    }
}
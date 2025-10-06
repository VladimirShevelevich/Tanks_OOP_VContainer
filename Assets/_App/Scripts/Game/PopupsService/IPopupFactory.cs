using UniRx;

namespace Game.Popups.PopupFactories
{
    public interface IPopupFactory
    {
        void Create(CompositeDisposable disposer);
    }
}
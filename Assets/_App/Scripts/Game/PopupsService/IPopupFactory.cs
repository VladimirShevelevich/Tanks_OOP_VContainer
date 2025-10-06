using UniRx;

namespace Game.Popups
{
    public interface IPopupFactory
    {
        void Create(CompositeDisposable disposer);
    }
}
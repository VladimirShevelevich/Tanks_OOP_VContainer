using JetBrains.Annotations;
using UniRx;

namespace Game.Popups
{
    [UsedImplicitly]
    public class PopupsService
    {
        private readonly PopupsFactory _popupsFactory;

        public PopupsService(PopupsFactory popupsFactory)
        {
            _popupsFactory = popupsFactory;
        }
        
        public void CreatePopup(PopupType popupType, CompositeDisposable disposer = null) =>
            _popupsFactory.CreatePopup(popupType, disposer);
    }   
}
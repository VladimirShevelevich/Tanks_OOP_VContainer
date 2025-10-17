using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
using UnityEngine;

namespace Game.Popups
{
    [UsedImplicitly]
    public class PopupsService : BaseDisposable
    {
        private readonly PopupsFactory _popupsFactory;

        public PopupsService(PopupsFactory popupsFactory)
        {
            _popupsFactory = popupsFactory;
        }
        
        public void CreatePopup(PopupType popupType, CompositeDisposable disposer = null)
        {
            var popup = _popupsFactory.CreatePopup(popupType, disposer);
            AddDisposable(
                popup.OnClosed.Subscribe(DisposePopup));
        }

        private void DisposePopup(Popup popup) =>
            Object.Destroy(popup);
    }   
}
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

        private PopupType _openedPopupType;

        public PopupsService(PopupsFactory popupsFactory)
        {
            _popupsFactory = popupsFactory;
        }
        
        public void CreatePopup(PopupType popupType, CompositeDisposable disposer = null)
        {
            if (_openedPopupType == popupType)
            {
                Debug.Log($"{popupType} popup is already opened");
                return;
            }
            
            var popup = _popupsFactory.Create(popupType, disposer);
            _openedPopupType = popupType;
            AddDisposable(popup.OnClosed.Subscribe(OnPopupClosed));
        }

        private void OnPopupClosed(Popup popup)
        {
            _openedPopupType = PopupType.None;
            Object.Destroy(popup.gameObject);
        }
    }   
}
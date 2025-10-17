using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
using UnityEngine;
using VContainer;

namespace Game.Popups
{
    [UsedImplicitly]
    public class PopupsFactory : BaseDisposable
    {
        private readonly PopupsContent _popupsContent;
        private readonly Canvas _uiCanvas;
        private readonly IObjectResolver _objectResolver;
        
        public PopupsFactory(PopupsContent popupsContent, Canvas uiCanvas, IObjectResolver objectResolver)
        {
            _popupsContent = popupsContent;
            _uiCanvas = uiCanvas;
            _objectResolver = objectResolver;
        }
        
        public Popup Create(PopupType popupType, CompositeDisposable disposer = null)
        {
            var popup = CreateView(popupType, disposer);
            _objectResolver.Inject(popup);
            return popup;
        }
        
        private Popup CreateView(PopupType popupType, CompositeDisposable disposer)
        {
            var prefab = _popupsContent.PopupByType(popupType);
            var screen = Object.Instantiate(prefab, _uiCanvas.transform);
            disposer.Add(new GameObjectDisposer(screen.gameObject));
            return screen;
        }

    }
}
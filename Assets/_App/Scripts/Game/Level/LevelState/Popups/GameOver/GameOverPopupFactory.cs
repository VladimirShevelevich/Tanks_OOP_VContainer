using Game.Popups;
using Tools.Disposable;
using UniRx;
using UnityEngine;
using VContainer;

namespace Game.Level.ResultScreen
{
    public class GameOverPopupFactory : PopupFactory
    {
        private readonly PopupsContent _popupsContent;
        private readonly Canvas _uiCanvas;
        private readonly IObjectResolver _objectResolver;

        public GameOverPopupFactory(PopupsContent popupsContent, Canvas uiCanvas, IObjectResolver objectResolver)
        {
            _popupsContent = popupsContent;
            _uiCanvas = uiCanvas;
            _objectResolver = objectResolver;
        }
        
        public override Popup Create(CompositeDisposable disposer)
        {
            var view = CreateView(disposer);
            _objectResolver.Inject(view);
            return view;
        }
        
        private GameOverPopupView CreateView(CompositeDisposable disposer)
        {
            var screen = Object.Instantiate(_popupsContent.GameOverPopupViewPrefab, _uiCanvas.transform);
            disposer.Add(new GameObjectDisposer(screen.gameObject));
            return screen;
        }

    }
}
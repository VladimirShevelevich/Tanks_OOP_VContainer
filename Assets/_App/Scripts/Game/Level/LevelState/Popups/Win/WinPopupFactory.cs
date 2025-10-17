using Game.Level.ResultScreen;
using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
using UnityEngine;
using VContainer;

namespace Game.Popups.PopupFactories
{
    [UsedImplicitly]
    public class WinPopupFactory : PopupFactory
    {
        private readonly PopupsContent _popupsContent;
        private readonly Canvas _uiCanvas;
        private readonly IObjectResolver _objectResolver;
        private readonly LevelCreator _levelCreator;

        public WinPopupFactory(PopupsContent popupsContent,
            Canvas uiCanvas, IObjectResolver objectResolver)
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

        private WinPopupView CreateView(CompositeDisposable disposer)
        {
            var screen = Object.Instantiate(_popupsContent.WinPopupViewPrefab, _uiCanvas.transform);
            disposer.Add(new GameObjectDisposer(screen.gameObject));
            return screen;
        }
    }
}
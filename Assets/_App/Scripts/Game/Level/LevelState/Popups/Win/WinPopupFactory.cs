using Game.Level.ResultScreen;
using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
using UnityEngine;

namespace Game.Popups.PopupFactories
{
    [UsedImplicitly]
    public class WinPopupFactory : PopupFactory
    {
        private readonly PopupsContent _popupsContent;
        private readonly Canvas _uiCanvas;
        private readonly LevelCreator _levelCreator;

        public WinPopupFactory(PopupsContent popupsContent,
            Canvas uiCanvas,
            LevelCreator levelCreator)
        {
            _popupsContent = popupsContent;
            _uiCanvas = uiCanvas;
            _levelCreator = levelCreator;
        }
        
        public override void Create(CompositeDisposable disposer)
        {
            var view = CreateView(disposer);
            var presenter = new WinPopupPresenter(_levelCreator, view);
            disposer?.Add(presenter);
        }

        private WinPopupView CreateView(CompositeDisposable disposer)
        {
            var screen = Object.Instantiate(_popupsContent.WinPopupViewPrefab, _uiCanvas.transform);
            disposer.Add(new GameObjectDisposer(screen.gameObject));
            return screen;
        }
    }
}
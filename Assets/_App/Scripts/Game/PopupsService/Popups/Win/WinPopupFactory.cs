using Game.Level.ResultScreen;
using JetBrains.Annotations;
using Tools.Disposable;
using UnityEngine;
using VContainer;

namespace Game.Popups.PopupFactories
{
    [UsedImplicitly]
    public class WinPopupFactory : BaseDisposable, IPopupFactory
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
        
        public void Create()
        {
            var view = CreateView();
            var presenter = new WinPopupPresenter(_levelCreator, view);
            AddDisposable(presenter);
        }

        private WinPopupView CreateView()
        {
            var screen = Object.Instantiate(_popupsContent.WinPopupViewPrefab, _uiCanvas.transform);
            AddDisposable(new GameObjectDisposer(screen.gameObject));
            return screen;
        }
    }
}
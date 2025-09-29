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
        private readonly LevelResultUIContent _levelResultUIContent;
        private readonly Canvas _uiCanvas;
        private readonly LevelCreator _levelCreator;

        public WinPopupFactory(LevelResultUIContent levelResultUIContent,
            Canvas uiCanvas,
            LevelCreator levelCreator)
        {
            _levelResultUIContent = levelResultUIContent;
            _uiCanvas = uiCanvas;
            _levelCreator = levelCreator;
        }
        
        public void Create()
        {
            var view = CreateView();
            var presenter = new WinPopupPresenter(_levelCreator, view);
            AddDisposable(presenter);
        }

        private WinScreen CreateView()
        {
            var screen = Object.Instantiate(_levelResultUIContent.WinScreenPrefab, _uiCanvas.transform);
            AddDisposable(new GameObjectDisposer(screen.gameObject));
            return screen;
        }
    }
}
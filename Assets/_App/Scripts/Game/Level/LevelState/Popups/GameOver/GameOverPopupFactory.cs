using Game.Popups;
using Tools.Disposable;
using UniRx;
using UnityEngine;

namespace Game.Level.ResultScreen
{
    public class GameOverPopupFactory : PopupFactory
    {
        private readonly PopupsContent _popupsContent;
        private readonly Canvas _uiCanvas;
        private readonly LevelCreator _levelCreator;

        public GameOverPopupFactory(PopupsContent popupsContent,
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
            var presenter = new GameOverPopupPresenter(_levelCreator, view);
            disposer?.Add(presenter);
        }
        
        private GameOverPopupView CreateView(CompositeDisposable disposer)
        {
            var screen = Object.Instantiate(_popupsContent.GameOverPopupViewPrefab, _uiCanvas.transform);
            disposer.Add(new GameObjectDisposer(screen.gameObject));
            return screen;
        }

    }
}
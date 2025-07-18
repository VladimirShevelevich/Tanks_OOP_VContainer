using Game.Level.LevelState;
using JetBrains.Annotations;
using Tools.Disposable;
using VContainer.Unity;
using UniRx;
using UnityEngine;

namespace Game.Level.ResultScreen
{
    [UsedImplicitly]
    public class ResultScreenPresenter : BaseDisposable, IInitializable
    {
        private readonly LevelStateService _levelStateService;
        private readonly Canvas _uiCanvas;
        private readonly LevelResultUIContent _levelResultUIContent;
        private readonly LevelCreator _levelCreator;

        public ResultScreenPresenter(LevelStateService levelStateService, 
            Canvas uiCanvas, 
            LevelResultUIContent levelResultUIContent,
            LevelCreator levelCreator)
        {
            _levelStateService = levelStateService;
            _uiCanvas = uiCanvas;
            _levelResultUIContent = levelResultUIContent;
            _levelCreator = levelCreator;
        }

        public void Initialize()
        {
            AddDisposable(
                _levelStateService.CurrentState.Subscribe(HandleLevelStateChange));
        }

        private void HandleLevelStateChange(LevelStateType newState)
        {
            switch (newState)
            {
                case LevelStateType.Win:
                    CreateWinScreen();
                    break;
                case LevelStateType.GameOver:
                    CreateGameOverScreen();
                    break;
            }
        }

        private void CreateWinScreen()
        {
            var screen = Object.Instantiate(_levelResultUIContent.WinScreenPrefab, _uiCanvas.transform);
            AddDisposable(new GameObjectDisposer(screen.gameObject));
        }

        private void CreateGameOverScreen()
        {
            var screen = Object.Instantiate(_levelResultUIContent.GameOverScreenPrefab, _uiCanvas.transform);
            AddDisposable(screen.OnRestartClick.Subscribe(_ => 
                HandleRestartClick()));
            
            AddDisposable(new GameObjectDisposer(screen.gameObject));
        }

        private void HandleRestartClick()
        {
            _levelCreator.TriggerLevelReload();
        }
    }
}
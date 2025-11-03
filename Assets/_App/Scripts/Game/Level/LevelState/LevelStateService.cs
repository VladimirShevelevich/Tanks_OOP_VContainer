using Game.Level.Config;
using Game.Level.Player;
using Game.Level.Scores;
using Game.Popups;
using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
using VContainer.Unity;

namespace Game.Level.LevelState
{
    [UsedImplicitly]
    public class LevelStateService : BaseDisposable, IInitializable
    {
        public IReadOnlyReactiveProperty<LevelStateType> CurrentState => _currentState;
        private readonly ReactiveProperty<LevelStateType> _currentState = new();

        private readonly ScoresService _scoresService;
        private readonly PlayerService _playerService;
        private readonly LevelConfig _levelConfig;
        private readonly PopupsService _popupsService;

        public LevelStateService(ScoresService scoresService, 
            PlayerService playerService, 
            LevelConfig levelConfig,
            PopupsService popupsService)
        {
            _scoresService = scoresService;
            _playerService = playerService;
            _levelConfig = levelConfig;
            _popupsService = popupsService;
        }
        
        public void Initialize()
        {
            AddDisposable(
                _scoresService.CurrentScore.Subscribe(HandleScoreChange));
            
            AddDisposable(
                _playerService.OnPlayerDeath.Subscribe(_=> HandlePlayerDeath()));
            
            _currentState.Value = LevelStateType.GameLoop;
        }

        private void HandlePlayerDeath()
        {
            SetGameOver();
        }

        private void HandleScoreChange(int newScore)
        {
            if (newScore >= _levelConfig.ScoreGoal)
                SetWin();
        }

        private void SetWin()
        {
            _currentState.Value = LevelStateType.Win;
            CreateResultPopup(PopupType.Win);
        }

        private void SetGameOver()
        {
            _currentState.Value = LevelStateType.GameOver;
            CreateResultPopup(PopupType.GameOver);
        }

        private void CreateResultPopup(PopupType popupType)
        {
            _popupsService.CreatePopup(popupType);
        }
    }
}
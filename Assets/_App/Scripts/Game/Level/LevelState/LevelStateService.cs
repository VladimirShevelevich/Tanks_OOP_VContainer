using Game.Level.Config;
using Game.Level.Player;
using Game.Level.Scores;
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

        public LevelStateService(ScoresService scoresService, PlayerService playerService, LevelConfig levelConfig)
        {
            _scoresService = scoresService;
            _playerService = playerService;
            _levelConfig = levelConfig;
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
            _currentState.Value = LevelStateType.GameOver;
        }

        private void HandleScoreChange(int newScore)
        {
            if (newScore >= _levelConfig.ScoreGoal)
                _currentState.Value = LevelStateType.Win;
        }
    }
}
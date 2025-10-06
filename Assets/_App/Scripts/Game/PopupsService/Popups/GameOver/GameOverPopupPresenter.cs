using Tools.Disposable;
using UniRx;

namespace Game.Level.ResultScreen
{
    public class GameOverPopupPresenter : BaseDisposable
    {
        private readonly LevelCreator _levelCreator;

        public GameOverPopupPresenter(LevelCreator levelCreator, GameOverPopupView gameOverPopupView)
        {
            _levelCreator = levelCreator;
            AddDisposable(
                gameOverPopupView.OnRestartClick.Subscribe(_ => HandleRestartLevelClick()));
        }

        private void HandleRestartLevelClick()
        {
            _levelCreator.ReloadLevel();
        }
    }
}
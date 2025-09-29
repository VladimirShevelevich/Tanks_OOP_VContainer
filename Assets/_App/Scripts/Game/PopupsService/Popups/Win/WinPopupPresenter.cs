using Game.Level.ResultScreen;
using Tools.Disposable;
using UniRx;

namespace Game.Popups.PopupFactories
{
    public class WinPopupPresenter : BaseDisposable
    {
        private readonly LevelCreator _levelCreator;

        public WinPopupPresenter(LevelCreator levelCreator, WinScreen winScreen)
        {
            _levelCreator = levelCreator;
            AddDisposable(winScreen.OnNextLevelClick.Subscribe(_ => 
                HandleNextLevelClick()));
        }

        private void HandleNextLevelClick()
        {
            _levelCreator.LoadNextLevel();
        }
    }
}
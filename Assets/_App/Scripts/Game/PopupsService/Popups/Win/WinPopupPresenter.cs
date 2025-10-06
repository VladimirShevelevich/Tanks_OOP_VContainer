using Game.Level.ResultScreen;
using Tools.Disposable;
using UniRx;

namespace Game.Popups.PopupFactories
{
    public class WinPopupPresenter : BaseDisposable
    {
        private readonly LevelCreator _levelCreator;

        public WinPopupPresenter(LevelCreator levelCreator, WinPopupView winPopupView)
        {
            _levelCreator = levelCreator;
            AddDisposable(winPopupView.OnNextLevelClick.Subscribe(_ => 
                HandleNextLevelClick()));
        }

        private void HandleNextLevelClick()
        {
            _levelCreator.LoadNextLevel();
        }
    }
}
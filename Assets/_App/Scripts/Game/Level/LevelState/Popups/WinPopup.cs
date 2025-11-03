using Game.Popups;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.Level.LevelState
{
    public class WinPopup : Popup
    {
        [SerializeField] private Button _nextButton;
        private LevelCreator _levelCreator;

        [Inject]
        public void Construct(LevelCreator levelCreator)
        {
            _levelCreator = levelCreator;
        }

        private void Awake()
        {
            _nextButton.OnClickAsObservable().Subscribe(_ => 
                    HandleNextLevelClick()).AddTo(this);
        }
        
        private void HandleNextLevelClick()
        {
            _levelCreator.LoadNextLevel();
            Close();
        }

    }
}
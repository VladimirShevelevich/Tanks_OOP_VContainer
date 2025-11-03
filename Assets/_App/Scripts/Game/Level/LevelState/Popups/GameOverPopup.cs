using Game.Popups;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.Level.LevelState
{
    public class GameOverPopup : Popup
    {
        [SerializeField] private Button _restartButton;
        private LevelCreator _levelCreator;

        [Inject]
        public void Construct(LevelCreator levelCreator)
        {
            _levelCreator = levelCreator;
        }
        
        private void Awake()
        {
            _restartButton.OnClickAsObservable().Subscribe(_ => 
                HandleRestartLevelClick()).AddTo(this);
        }
        
        private void HandleRestartLevelClick()
        {
            _levelCreator.ReloadLevel();
            Close();
        }

    }
}
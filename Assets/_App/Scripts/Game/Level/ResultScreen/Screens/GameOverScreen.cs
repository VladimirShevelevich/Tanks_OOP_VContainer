using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Level.ResultScreen
{
    public class GameOverScreen : MonoBehaviour
    {
        public IObservable<Unit> OnRestartClick => _onRestartClick;
        private readonly ReactiveCommand _onRestartClick = new();
        
        [SerializeField] private Button _restartButton;

        private void Awake()
        {
            _restartButton.OnClickAsObservable().Subscribe(_ => 
                _onRestartClick.Execute()).
                AddTo(this);
        }
    }
}
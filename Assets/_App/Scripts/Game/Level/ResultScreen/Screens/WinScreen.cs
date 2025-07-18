using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Level.ResultScreen
{
    public class WinScreen : MonoBehaviour
    {
        public IObservable<Unit> OnNextLevelClick => _onNextLevelClick;
        private readonly ReactiveCommand _onNextLevelClick = new();
        
        [SerializeField] private Button _nextButton;

        private void Awake()
        {
            _nextButton.OnClickAsObservable().Subscribe(_ => 
                    _onNextLevelClick.Execute()).AddTo(this);
        }
    }
}
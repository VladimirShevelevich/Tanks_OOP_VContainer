using System;
using DG.Tweening;
using UniRx;
using UnityEngine;

namespace Game.Popups
{
    public class Popup : MonoBehaviour
    {
        public IReactiveCommand<Popup> OnClosed => _onClosed;
        private readonly ReactiveCommand<Popup> _onClosed = new();
        
        [SerializeField] private Transform _root;
        [SerializeField] private Settings _settings;

        protected virtual void Close()
        {
            _root.DOScaleX(0, _settings.CloseDuration).OnComplete(() =>
            {
                _onClosed.Execute(this);
            }).SetLink(gameObject);
        }
        
        [Serializable]
        public class Settings
        {
            [field: SerializeField] public float CloseDuration { get; private set; } = 0.2f;
        }
    }
}
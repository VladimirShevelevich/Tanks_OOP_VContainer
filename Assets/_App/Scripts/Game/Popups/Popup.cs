using DG.Tweening;
using UniRx;
using UnityEngine;

namespace Game.Popups
{
    public abstract class Popup : MonoBehaviour
    {
        public IReactiveCommand<Popup> OnClosed => _onClosed;
        private readonly ReactiveCommand<Popup> _onClosed = new();
        
        [SerializeField] private Transform _root;

        protected virtual void Close()
        {
            _root.DOScaleX(0, 0.2f).OnComplete(() =>
            {
                _onClosed.Execute(this);
            }).SetLink(gameObject);
        }
        
    }
}
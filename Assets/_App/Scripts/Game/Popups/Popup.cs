using DG.Tweening;
using UniRx;
using UnityEngine;

namespace Game.Popups
{
    public abstract class Popup : MonoBehaviour
    {
        public IReactiveCommand<Unit> OnClosed => _onClosed;
        private readonly ReactiveCommand<Unit> _onClosed = new();
        
        [SerializeField] private Transform _root;
        
        public virtual void Close()
        {
            _root.DOScaleX(0, 0.2f).OnComplete(() =>
            {
                _onClosed.Execute(Unit.Default);
            }).SetLink(gameObject);
        }
        
    }
}
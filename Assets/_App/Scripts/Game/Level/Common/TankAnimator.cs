using System;
using DG.Tweening;
using UnityEngine;

namespace Game.Level.Common
{
    public class TankAnimator : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;

        public void PlayDamage()
        {
            _renderer.material.DOKill();
            _renderer.material.DOColor(Color.black, 0.05f).SetLoops(2, LoopType.Yoyo);
        }
        
        public void PlayDestroy(Action onComplete)
        {
            transform.DOScale(0, 0.15f).
                OnComplete(onComplete.Invoke);
        }
    }
}
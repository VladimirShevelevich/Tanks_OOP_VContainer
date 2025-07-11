using System;
using UniRx;
using UnityEngine;

namespace Game.Level.Enemy
{
    public class EnemyTriggerDetector : MonoBehaviour
    {
        public IObservable<Collider> OnTrigger => _onTrigger;
        private readonly ReactiveCommand<Collider> _onTrigger = new();
        
        private void OnTriggerEnter(Collider other)
        {
            _onTrigger.Execute(other);
        }
    }
}
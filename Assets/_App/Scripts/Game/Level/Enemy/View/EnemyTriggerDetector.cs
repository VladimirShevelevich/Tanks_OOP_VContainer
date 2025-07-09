using System;
using UniRx;
using UnityEngine;

namespace Game.Level.Enemy
{
    public class EnemyTriggerDetector : MonoBehaviour
    {
        public IObservable<Collider> OnTrigger => _onTrigger;
        private ReactiveCommand<Collider> _onTrigger;
        
        private void OnTriggerEnter(Collider other)
        {
            _onTrigger.Execute(other);
        }
    }
}
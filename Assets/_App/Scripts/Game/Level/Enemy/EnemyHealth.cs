using System;
using Game.Level.Projectile;
using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
using UnityEngine;

namespace Game.Level.Enemy
{
    [UsedImplicitly]
    public class EnemyHealth : BaseDisposable
    {
        private EnemyModel _enemyModel;

        public void BindModel(EnemyModel model)
        {
            _enemyModel = model;
        }
        
        public void BindView(GameObject view)
        {
            AddDisposable(
                SubscribeOnProjectileTrigger(view));
        }

        private IDisposable SubscribeOnProjectileTrigger(GameObject view)
        {
            return view.GetComponent<EnemyTriggerDetector>().OnTrigger.Where(x =>
                x.GetComponent<ProjectileView>()).
                Subscribe(_ => OnTriggeredByProjectile());
        }

        private void OnTriggeredByProjectile()
        {
            DecreaseHealth();
        }

        private void DecreaseHealth()
        {
            _enemyModel.DecreaseHealth(1);
        }
    }
}
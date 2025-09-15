using System;
using Game.Level.Common;
using Game.Level.Projectile;
using Game.Level.Scores;
using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
using UnityEngine;

namespace Game.Level.Enemy
{
    [UsedImplicitly]
    public class EnemyHealth : BaseDisposable
    {
        private readonly EnemyModel _enemyModel;
        private readonly TankAnimator _tankAnimator;
        private readonly ReactiveCommand _onDestroyed;

        public EnemyHealth(EnemyModel enemyModel, GameObject view, ReactiveCommand onDestroyed)
        {
            _enemyModel = enemyModel;
            _onDestroyed = onDestroyed;
            _tankAnimator = view.GetComponent<TankAnimator>();
            AddDisposable(SubscribeOnProjectileTrigger(view));
        }

        private IDisposable SubscribeOnProjectileTrigger(GameObject view)
        {
            return view.GetComponent<TriggerDetector>().OnTrigger.Where(x =>
                x.GetComponent<ProjectileView>() && x.GetComponent<ProjectileView>().SourceType == ProjectileSourceType.Player).
                Subscribe(_ => OnTriggeredByProjectile());
        }

        private void OnTriggeredByProjectile()
        {
            DecreaseHealth();
        }

        private void DecreaseHealth()
        {
            _enemyModel.DecreaseHealth(1);
            if (_enemyModel.CurrentHealth.Value > 0)
            {
                _tankAnimator.PlayDamage();
                return;
            }

            OnDeath();
        }

        private void OnDeath()
        {
            _tankAnimator.PlayDestroy(() =>
            {
                _onDestroyed.Execute();
            });
        }
    }
}
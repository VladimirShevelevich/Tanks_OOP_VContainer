using System;
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
        private readonly EnemyAnimator _enemyAnimator;
        private readonly ReactiveCommand _onDestroyed;

        public EnemyHealth(EnemyModel enemyModel, GameObject view, ReactiveCommand onDestroyed)
        {
            _enemyModel = enemyModel;
            _onDestroyed = onDestroyed;
            _enemyAnimator = view.GetComponent<EnemyAnimator>();
            AddDisposable(SubscribeOnProjectileTrigger(view));
        }

        private IDisposable SubscribeOnProjectileTrigger(GameObject view)
        {
            return view.GetComponent<EnemyTriggerDetector>().OnTrigger.Where(x =>
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
            if (_enemyModel.Health.Value > 0)
            {
                _enemyAnimator.PlayDamage();
                return;
            }

            OnDeath();
        }

        private void OnDeath()
        {
            _enemyAnimator.PlayDestroy(() =>
            {
                _onDestroyed.Execute();
            });
        }
    }
}
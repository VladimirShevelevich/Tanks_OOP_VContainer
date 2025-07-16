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
        public IObservable<Unit> OnDisposeInvoked => _onDisposeInvoked;
        private readonly ReactiveCommand _onDisposeInvoked = new();

        private readonly ScoresService _scoresService;
        private EnemyModel _enemyModel;
        private EnemyAnimator _enemyAnimator;

        public EnemyHealth(ScoresService scoresService)
        {
            _scoresService = scoresService;
        }
        
        public void BindModel(EnemyModel model)
        {
            _enemyModel = model;
        }
        
        public void BindView(GameObject view)
        {
            _enemyAnimator = view.GetComponent<EnemyAnimator>();
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
            if (_enemyModel.Health.Value > 0)
            {
                _enemyAnimator.PlayDamage();
                return;
            }

            OnDeath();
        }

        private void OnDeath()
        {
            _scoresService.AddScores(1);
            _enemyAnimator.PlayDestroy(() =>
            {
                _onDisposeInvoked.Execute();
            });
        }
    }
}
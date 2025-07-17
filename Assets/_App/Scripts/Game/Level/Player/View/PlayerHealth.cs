using System;
using Game.Level.Common;
using Game.Level.Projectile;
using Tools.Disposable;
using UniRx;
using UnityEngine;

namespace Game.Level.Player
{
    public class PlayerHealth : BaseDisposable
    {
        private readonly PlayerModel _playerModel;
        private readonly ReactiveCommand _onPlayerDeath;
        private readonly TankAnimator _tankAnimator;

        public PlayerHealth(PlayerModel playerModel, GameObject playerView, ReactiveCommand onPlayerDeath)
        {
            _playerModel = playerModel;
            _onPlayerDeath = onPlayerDeath;
            _tankAnimator = playerView.GetComponent<TankAnimator>();
            
            AddDisposable(SubscribeOnProjectileTrigger(playerView));
        }
        
        private IDisposable SubscribeOnProjectileTrigger(GameObject view)
        {
            return view.GetComponent<TriggerDetector>().OnTrigger.Where(x =>
                    x.GetComponent<ProjectileView>() && x.GetComponent<ProjectileView>().SourceType == ProjectileSourceType.Enemy).
                Subscribe(_ => OnTriggeredByProjectile());
        }

        private void OnTriggeredByProjectile()
        {
            DecreaseHealth();
        }

        private void DecreaseHealth()
        {
            _playerModel.DecreaseHealth(1);
            if (_playerModel.CurrentHealth.Value > 0)
            {
                _tankAnimator.PlayDamage();
                return;
            }

            OnDeath();
        }

        private void OnDeath()
        {
            _onPlayerDeath.Execute();
        }
    }
}
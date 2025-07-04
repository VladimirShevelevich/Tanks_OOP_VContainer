using System;
using Game.Level.Player.Projectile;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace Game.Level.Player
{
    [UsedImplicitly]
    public class PlayerShooter : IDisposable, ITickable
    {
        private readonly ProjectileContent _projectileContent;
        private PlayerView _playerView;
        private readonly CompositeDisposable _disposable = new();

        public PlayerShooter(ProjectileContent projectileContent)
        {
            _projectileContent = projectileContent;
        }
        
        public void BindView(PlayerView playerView)
        {
            _playerView = playerView;
        }
        
        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _playerView.Shoot(new ShootRequest
                {
                    ProjectilePrefab = _projectileContent.ProjectilePrefab,
                    Speed = _projectileContent.Speed
                });
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
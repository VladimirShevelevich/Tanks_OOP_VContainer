using System;
using Game.Level.Player;
using Game.Level.Projectile;
using Tools.Disposable;
using UniRx;
using UnityEngine;
using VContainer;

namespace Game.Level.Enemy
{
    public class EnemyShooter : MonoBehaviour
    {
        [SerializeField] private Transform _projectileSpawnPoint;
        [SerializeField] private Transform _towerTransform;
        
        private ProjectileFactory _projectileFactory;
        private EnemyContent.ShootingContent _shootingContent;
        private PlayerService _playerService;

        [Inject]
        public void Construct(ProjectileFactory projectileFactory, EnemyContent enemyContent, PlayerService playerService)
        {
            _shootingContent = enemyContent.Shooting;
            _projectileFactory = projectileFactory;
            _playerService = playerService;
        }

        private void Start()
        {
            ExecuteShooting();
        }

        private void ExecuteShooting()
        {
            Observable.Timer(TimeSpan.FromSeconds(_shootingContent.ShootFrequency)).
                Repeat().
                Subscribe(_ => Shoot()).
                AddTo(this);
        }

        private void Shoot()
        {
            var playerPosition = _playerService.PlayerModel.CurrentPosition;
            _towerTransform.LookAt(playerPosition);
            
            var rotation = Quaternion.LookRotation(playerPosition - transform.position);
            var projectile = _projectileFactory.Create(_projectileSpawnPoint.position, rotation);
            Destroy(projectile.gameObject, 3);
            new GameObjectDisposer(projectile.gameObject).AddTo(this);
        }
    }
}
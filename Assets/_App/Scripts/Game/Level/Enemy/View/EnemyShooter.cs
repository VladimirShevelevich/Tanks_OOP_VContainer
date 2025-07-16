using System;
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
        
        private ProjectileFactory _projectileFactory;
        private EnemyContent.ShootingContent _shootingContent;

        [Inject]
        public void Construct(ProjectileFactory projectileFactory, EnemyContent enemyContent)
        {
            _shootingContent = enemyContent.Shooting;
            _projectileFactory = projectileFactory;
        }

        private void Start()
        {
            ExecuteShooting();
        }

        private void ExecuteShooting()
        {
            Observable.Timer(TimeSpan.FromSeconds(_shootingContent.ShootFrequency)).
                Subscribe(_ => Shoot()).
                AddTo(this);
        }

        private void Shoot()
        {
            var projectile = _projectileFactory.Create(_projectileSpawnPoint.position, transform.rotation);
            Destroy(projectile.gameObject, 3);
            new GameObjectDisposer(projectile.gameObject).AddTo(this);
        }
    }
}
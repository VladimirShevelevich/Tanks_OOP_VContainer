using System;
using Game.Level.LevelState;
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
        private LevelStateService _levelStateService;

        [Inject]
        public void Construct(ProjectileFactory projectileFactory, 
            EnemyContent enemyContent, 
            PlayerService playerService,
            LevelStateService levelStateService)
        {
            _shootingContent = enemyContent.Shooting;
            _projectileFactory = projectileFactory;
            _playerService = playerService;
            _levelStateService = levelStateService;
        }

        private void Start()
        {
            ExecuteShooting();
        }

        private void Update()
        {
            RotateTowerToPlayer();
        }

        private void RotateTowerToPlayer()
        {
            var playerPosition = _playerService.PlayerModel.CurrentPosition;
            _towerTransform.LookAt(playerPosition);
        }

        private void ExecuteShooting()
        {
            Observable.Timer(TimeSpan.FromSeconds(_shootingContent.ShootFrequency)).
                Repeat().
                Where(x => _levelStateService.CurrentState.Value == LevelStateType.GameLoop).
                Subscribe(_ => Shoot()).
                AddTo(this);
        }

        private void Shoot()
        {
            var playerPosition = _playerService.PlayerModel.CurrentPosition;
            var rotation = Quaternion.LookRotation(playerPosition - transform.position);
            var projectile = _projectileFactory.Create(_projectileSpawnPoint.position, rotation, ProjectileSourceType.Enemy);
            Destroy(projectile.gameObject, 3);
            new GameObjectDisposer(projectile.gameObject).AddTo(this);
        }
    }
}
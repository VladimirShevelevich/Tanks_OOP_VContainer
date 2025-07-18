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

        private void LateUpdate()
        {
            RotateTowerToPlayer();
        }

        private void RotateTowerToPlayer()
        {
            var playerPosition = _playerService.PlayerModel.CurrentPosition;
            var targetPosition = new Vector3(playerPosition.x, _towerTransform.position.y, playerPosition.z);
            var targetRotation = Quaternion.LookRotation(targetPosition - _towerTransform.position);
            _towerTransform.rotation = Quaternion.Slerp(_towerTransform.rotation, targetRotation,
                Time.deltaTime * _shootingContent.TowerRotationSpeed);
        }

        private void ExecuteShooting()
        {
            Observable.Timer(TimeSpan.FromSeconds(_shootingContent.ShootingInterval)).
                Repeat().
                Where(x => _levelStateService.CurrentState.Value == LevelStateType.GameLoop).
                Subscribe(_ => Shoot()).
                AddTo(this);
        }

        private void Shoot()
        {
            var rotation = _towerTransform.rotation;
            rotation.x = 0;
            var projectile = _projectileFactory.Create(_projectileSpawnPoint.position, rotation, ProjectileSourceType.Enemy);
            Destroy(projectile.gameObject, 10);
            new GameObjectDisposer(projectile.gameObject).AddTo(this);
        }
    }
}
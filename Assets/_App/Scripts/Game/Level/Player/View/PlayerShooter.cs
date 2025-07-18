using Game.Level.Input;
using Game.Level.LevelState;
using Game.Level.Projectile;
using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
using UnityEngine;
using VContainer;

namespace Game.Level.Player
{
    [UsedImplicitly]
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private Transform _projectileSpawnPoint;
        
        private IInputService _inputService;
        private ProjectileFactory _projectileFactory;
        private LevelStateService _levelStateService;

        [Inject]
        public void Construct (IInputService inputService, ProjectileFactory projectileFactory, LevelStateService levelStateService)
        {
            _inputService = inputService;
            _projectileFactory = projectileFactory;
            _levelStateService = levelStateService;
        }
        
        public void Update()
        {
            if (_levelStateService.CurrentState.Value != LevelStateType.GameLoop)
                return;
                
            if (_inputService.ShootKeyDown())
                Shoot();
        }

        private void Shoot()
        {
            var projectile = _projectileFactory.Create(_projectileSpawnPoint.position, transform.rotation, ProjectileSourceType.Player);
            Destroy(projectile.gameObject, 10);
            new GameObjectDisposer(projectile.gameObject).AddTo(this);
        }
    }
}
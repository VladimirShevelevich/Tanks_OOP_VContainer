using Game.Level.Input;
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

        [Inject]
        public void Construct (IInputService inputService, ProjectileFactory projectileFactory)
        {
            _inputService = inputService;
            _projectileFactory = projectileFactory;
        }
        
        public void Update()
        {
            if (_inputService.ShootKeyDown())
                Shoot();
        }

        private void Shoot()
        {
            var projectile = _projectileFactory.Create(_projectileSpawnPoint.position, transform.rotation, ProjectileSourceType.Player);
            Destroy(projectile.gameObject, 3);
            new GameObjectDisposer(projectile.gameObject).AddTo(this);
        }
    }
}
using Game.Level.Input;
using Game.Level.Player.Projectile;
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
        
        private ProjectileContent _projectileContent;
        private IInputService _inputService;

        [Inject]
        public void Construct (ProjectileContent projectileContent, IInputService inputService)
        {
            _projectileContent = projectileContent;
            _inputService = inputService;
        }
        
        public void Update()
        {
            if (_inputService.ShootKeyDown())
                Shoot(new ShootRequest
                {
                    ProjectilePrefab = _projectileContent.ProjectilePrefab,
                    Speed = _projectileContent.Speed
                });
        }

        private void Shoot(ShootRequest shootRequest)
        {
            var obj = Instantiate(shootRequest.ProjectilePrefab, _projectileSpawnPoint.position, transform.rotation);
            obj.Init(shootRequest.Speed);
            new GameObjectDisposer(obj.gameObject).AddTo(this);
        }
    }
}
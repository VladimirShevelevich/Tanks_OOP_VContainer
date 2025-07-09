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

        [Inject]
        public void Construct (ProjectileContent projectileContent)
        {
            _projectileContent = projectileContent;
        }
        
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
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
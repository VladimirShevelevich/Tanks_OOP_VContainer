using Tools.Disposable;
using UniRx;
using UnityEngine;

namespace Game.Level.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform _projectileSpawnPoint;


        public void Shoot(ShootRequest shootRequest)
        {
            var obj = Instantiate(shootRequest.ProjectilePrefab, _projectileSpawnPoint.position, transform.rotation);
            obj.Init(shootRequest.Speed);
            new GameObjectDisposer(obj.gameObject).AddTo(this);
        }
    }
}
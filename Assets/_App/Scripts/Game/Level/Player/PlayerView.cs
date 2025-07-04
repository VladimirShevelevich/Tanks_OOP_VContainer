using Tools.Disposable;
using UniRx;
using UnityEngine;

namespace Game.Level.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _projectileSpawnPoint;

        public void Move(float movement)
        {
            _characterController.Move(transform.forward * movement);
        }

        public void Rotate(float rotation)
        {
            transform.Rotate(Vector3.up, rotation);
        }

        public void Shoot(ShootRequest shootRequest)
        {
            var obj = Instantiate(shootRequest.ProjectilePrefab, _projectileSpawnPoint.position, transform.rotation);
            obj.Init(shootRequest.Speed);
            new GameObjectDisposer(obj.gameObject).AddTo(this);
        }
    }
}
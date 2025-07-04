using Tools.Disposable;
using UniRx;
using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Transform _projectileSpawnPoint;

        private PlayerContent _playerContent;
        
        public void BindPlayerContent(PlayerContent playerContent)
        {
            _playerContent = playerContent;
        }
        
        public void Move(float movement)
        {
            _characterController.Move(transform.forward * movement);
        }

        public void Rotate(float rotation)
        {
            transform.Rotate(Vector3.up, rotation);
        }

        public void Shoot()
        {
            var obj = Instantiate(_playerContent.ProjectilePrefab, _projectileSpawnPoint.position, transform.rotation);
            new GameObjectDisposer(obj.gameObject).AddTo(this);
        }
    }
}
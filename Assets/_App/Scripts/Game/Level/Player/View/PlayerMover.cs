using UnityEngine;

namespace Game.Level.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        
        private PlayerContent _playerContent;

        public void SetPlayerContent(PlayerContent playerContent)
        {
            _playerContent = playerContent;
        }
        
        public void Update()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");
            
            Rotate(horizontalInput * _playerContent.RotationSpeed * Time.deltaTime);
            Move(verticalInput * _playerContent.Speed * Time.deltaTime);
        }

        private void Move(float movement)
        {
            _characterController.Move(transform.forward * movement);
        }

        private void Rotate(float rotation)
        {
            transform.Rotate(Vector3.up, rotation);
        }
    }
}
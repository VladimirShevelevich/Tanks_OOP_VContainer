using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        
        public void Move(float movement)
        {
            _characterController.Move(transform.forward * movement);
        }

        public void Rotate(float rotation)
        {
            transform.Rotate(Vector3.up, rotation);
        }
    }
}
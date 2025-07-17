using System;
using Game.Level.Input;
using UnityEngine;
using VContainer;

namespace Game.Level.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        
        private PlayerContent _playerContent;
        private IInputService _inputService;
        private PlayerModel _playerModel;

        [Inject]
        public void Construct(PlayerContent playerContent, IInputService inputService)
        {
            _playerContent = playerContent;
            _inputService = inputService;
        }

        public void BindModel(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        private void Update()
        {
            var horizontalInput = _inputService.Axis().x;
            var verticalInput = _inputService.Axis().y;
            Rotate(horizontalInput * _playerContent.RotationSpeed * Time.deltaTime);
            Move(verticalInput * _playerContent.Speed * Time.deltaTime);
        }

        private void LateUpdate()
        {
            _playerModel.UpdatePosition(transform.position);
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
using System;
using Game.Level.Input;
using Game.Level.LevelState;
using UnityEngine;
using VContainer;

namespace Game.Level.Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        
        private PlayerContent _playerBaseContent;
        private IInputService _inputService;
        private PlayerModel _playerModel;
        private LevelStateService _levelStateService;

        [Inject]
        public void Construct(PlayerContent playerContent, IInputService inputService, LevelStateService levelStateService)
        {
            _playerBaseContent = playerContent;
            _inputService = inputService;
            _levelStateService = levelStateService;
        }

        public void BindModel(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        private void Update()
        {
            if (_levelStateService.CurrentState.Value == LevelStateType.GameLoop)
                Move();
        }

        private void Move()
        {
            var horizontalInput = _inputService.Axis().x;
            var verticalInput = _inputService.Axis().y;
            Rotate(horizontalInput * _playerBaseContent.RotationSpeed * Time.deltaTime);
            Move(verticalInput * _playerBaseContent.Speed * Time.deltaTime);
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
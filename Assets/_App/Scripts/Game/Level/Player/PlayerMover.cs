using System;
using UniRx;
using UnityEngine;

namespace Player
{
    public class PlayerMover : IDisposable
    {
        private PlayerView _playerView;
        private readonly CompositeDisposable _disposable = new();
        private readonly PlayerContent _playerContent;

        public PlayerMover(PlayerContent playerContent)
        {
            _playerContent = playerContent;
        }
        
        public void Initialize()
        {
            Observable.EveryUpdate().Subscribe(_ => Update()).
                AddTo(_disposable);
        }

        public void BindView(PlayerView playerView)
        {
            _playerView = playerView;
        }
        
        void Update()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");
            
            _playerView.Rotate(horizontalInput * _playerContent.RotationSpeed * Time.deltaTime);
            _playerView.Move(verticalInput * _playerContent.Speed * Time.deltaTime);

            // Rotate character
            //transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

            // Move character
            //Vector3 moveDirection = transform.forward * verticalInput * speed;
        
            //characterController.SimpleMove(moveDirection);
        }


        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
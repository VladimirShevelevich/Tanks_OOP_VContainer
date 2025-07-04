using System;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace Player
{
    [UsedImplicitly]
    public class PlayerMover : IDisposable, ITickable
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

        public void Tick()
        {
            throw new NotImplementedException();
        }

        void Update()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");
            
            _playerView.Rotate(horizontalInput * _playerContent.RotationSpeed * Time.deltaTime);
            _playerView.Move(verticalInput * _playerContent.Speed * Time.deltaTime);
        }


        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
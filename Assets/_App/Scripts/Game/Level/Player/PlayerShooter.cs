using System;
using UniRx;
using UnityEngine;

namespace Player
{
    public class PlayerShooter : IDisposable
    {
        private PlayerView _playerView;
        private readonly CompositeDisposable _disposable = new();
        
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
            if (Input.GetKeyDown(KeyCode.Space))
                _playerView.Shoot();
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
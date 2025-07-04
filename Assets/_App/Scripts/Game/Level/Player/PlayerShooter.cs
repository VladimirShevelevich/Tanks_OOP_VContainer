using System;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace Game.Level.Player
{
    [UsedImplicitly]
    public class PlayerShooter : IDisposable, ITickable
    {
        private PlayerView _playerView;
        private readonly CompositeDisposable _disposable = new();
        
        public void BindView(PlayerView playerView)
        {
            _playerView = playerView;
        }
        
        public void Tick()
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
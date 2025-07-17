using System;
using UniRx;
using UnityEngine;

namespace Game.Level.Player
{
    public class PlayerModel : IPlayerModel
    {
        public Vector3 CurrentPosition => _currentPosition;
        private Vector3 _currentPosition;

        public IReadOnlyReactiveProperty<int> CurrentHealth => _currentHealth;
        private readonly ReactiveProperty<int> _currentHealth = new();

        public PlayerModel(int initialHealth)
        {
            _currentHealth.Value = initialHealth;
        }
        
        public void UpdatePosition(Vector3 newPosition)
        {
            _currentPosition = newPosition;
        }

        public void DecreaseHealth(int amount)
        {
            _currentHealth.Value -= amount;
        }
    }
}
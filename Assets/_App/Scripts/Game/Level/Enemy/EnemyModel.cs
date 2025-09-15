using Game.Level.HealthBar;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;

namespace Game.Level.Enemy
{
    [UsedImplicitly]
    public class EnemyModel : IHealthProvider
    {
        public int MaxHealth => _enemyContent.InitialHealth;
        public IReadOnlyReactiveProperty<int> CurrentHealth => _health;
        
        private ReactiveProperty<int> _health;
        private readonly EnemyContent _enemyContent;

        public EnemyModel(EnemyContent enemyContent)
        {
            _enemyContent = enemyContent;
            SetInitialValues();
        }

        private void SetInitialValues()
        {
            _health = new ReactiveProperty<int>(_enemyContent.InitialHealth);
        }

        public void DecreaseHealth(int amount)
        {
            var newHealth = Mathf.Max(0, _health.Value - amount);
            _health.Value = newHealth;
            Debug.Log(_health.Value);
        }
    }
}
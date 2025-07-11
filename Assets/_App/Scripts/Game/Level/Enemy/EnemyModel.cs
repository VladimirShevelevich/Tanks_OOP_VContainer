using JetBrains.Annotations;
using UniRx;
using UnityEngine;

namespace Game.Level.Enemy
{
    [UsedImplicitly]
    public class EnemyModel
    {
        private readonly EnemyContent _enemyContent;
        public IReadOnlyReactiveProperty<int> Health => _health;
        private ReactiveProperty<int> _health;

        public EnemyModel(EnemyContent enemyContent)
        {
            _enemyContent = enemyContent;
            SetInitialValues();
        }

        private void SetInitialValues()
        {
            _health = new ReactiveProperty<int>(5);
        }

        public void DecreaseHealth(int amount)
        {
            var newHealth = Mathf.Max(0, _health.Value - amount);
            _health.Value = newHealth;
            Debug.Log(_health.Value);
        }
    }
}
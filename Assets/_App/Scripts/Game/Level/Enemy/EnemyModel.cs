using UniRx;
using UnityEngine;

namespace Game.Level.Enemy
{
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
            _health.Value -= amount;
            Debug.Log(_health.Value);
        }
    }
}
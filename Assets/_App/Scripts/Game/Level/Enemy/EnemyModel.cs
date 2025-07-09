using UniRx;

namespace Game.Level.Enemy
{
    public class EnemyModel
    {
        public IReadOnlyReactiveProperty<int> Health => _health;
        private ReactiveProperty<int> _health;

        public void DecreaseHealth(int amount)
        {
            _health.Value -= amount;
        }
    }
}
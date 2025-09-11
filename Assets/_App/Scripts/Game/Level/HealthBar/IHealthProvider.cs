using UniRx;

namespace Game.Level.HealthBar
{
    public interface IHealthProvider
    {
        public IReadOnlyReactiveProperty<int> CurrentHealth { get; }
        public int MaxHealth { get; }
    }
}
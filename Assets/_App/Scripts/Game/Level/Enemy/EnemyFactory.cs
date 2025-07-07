using VContainer;

namespace Game.Level.Enemy
{
    public class EnemyFactory
    {
        private readonly IObjectResolver _objectResolver;

        public EnemyFactory(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        public Enemy Create(EnemyContent.EnemyType enemyType)
        {
            var enemy = _objectResolver.Resolve<Enemy>();
            enemy.SetType(enemyType);
            return enemy;
        }
    }
}
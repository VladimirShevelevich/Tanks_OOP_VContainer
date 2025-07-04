using JetBrains.Annotations;
using VContainer.Unity;

namespace Game.Level.Enemy
{
    [UsedImplicitly]
    public class EnemySpawner : IInitializable
    {
        private readonly EnemyFactory _enemyFactory;

        public EnemySpawner(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }
        
        public void Initialize()
        {
            var enemy = _enemyFactory.Create(EnemyContent.EnemyType.Static);
            enemy.Init();
        }
    }
}
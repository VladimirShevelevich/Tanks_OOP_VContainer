using JetBrains.Annotations;
using Tools.Disposable;
using VContainer.Unity;

namespace Game.Level.Enemy
{
    [UsedImplicitly]
    public class EnemySpawner : BaseDisposable, IInitializable
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
            
            enemy = _enemyFactory.Create(EnemyContent.EnemyType.Patrol);
            enemy.Init();
        }
    }
}
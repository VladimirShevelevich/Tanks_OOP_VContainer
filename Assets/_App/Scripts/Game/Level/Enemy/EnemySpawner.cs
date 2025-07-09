using JetBrains.Annotations;
using Tools.Disposable;
using UnityEngine;
using VContainer.Unity;

namespace Game.Level.Enemy
{
    [UsedImplicitly]
    public class EnemySpawner : BaseDisposable, IInitializable
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly EnemyContent _enemyContent;

        public EnemySpawner(EnemyFactory enemyFactory, EnemyContent enemyContent)
        {
            _enemyFactory = enemyFactory;
            _enemyContent = enemyContent;
        }
        
        public void Initialize()
        {
            var enemy = _enemyFactory.Create(EnemyContent.EnemyType.Static, RandomPosition());
            enemy.Init();
            
            enemy = _enemyFactory.Create(EnemyContent.EnemyType.Patrol, RandomPosition());
            enemy.Init();
        }

        private Vector3 RandomPosition()
        {
            return new Vector3(
                Random.Range(-_enemyContent.SpawnArea.x, _enemyContent.SpawnArea.x),
                0,
                Random.Range(-_enemyContent.SpawnArea.y, _enemyContent.SpawnArea.y));
        }
    }
}
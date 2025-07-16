using Game.Level.Enemy.Requests;
using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
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
            SpawnEnemy(EnemyContent.EnemyType.Static);
            SpawnEnemy(EnemyContent.EnemyType.Patrol);
        }

        private void SpawnEnemy(EnemyContent.EnemyType enemyType)
        {
            var disposable = new CompositeDisposable();
            AddDisposable(disposable);
            _enemyFactory.Create(new CreateEnemyRequest
            {
                EnemyType = enemyType,
                Position = RandomPosition()
            }, disposable);
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
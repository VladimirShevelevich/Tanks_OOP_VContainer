using System;
using Game.Level.Enemy.Requests;
using Game.Level.Scores;
using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
using UnityEngine;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace Game.Level.Enemy
{
    [UsedImplicitly]
    public class EnemyService : BaseDisposable, IInitializable
    {
        private readonly EnemyFactory _enemyFactory;
        private readonly EnemyContent _enemyContent;
        private readonly ScoresService _scoresService;

        public EnemyService(EnemyFactory enemyFactory, EnemyContent enemyContent, ScoresService scoresService)
        {
            _enemyFactory = enemyFactory;
            _enemyContent = enemyContent;
            _scoresService = scoresService;
        }
        
        public void Initialize()
        {
            SpawnEnemy(EnemyContent.EnemyType.Static);
            SpawnEnemy(EnemyContent.EnemyType.Patrol);
        }
        
        private void SpawnEnemy(EnemyContent.EnemyType enemyType)
        {
            var enemyDisposable = new CompositeDisposable();
            var onDestroyed = new ReactiveCommand();
            AddDisposable(onDestroyed.Subscribe(_ =>
            {
                HandleEnemyDestroyed(enemyDisposable);
            }));
            AddDisposable(enemyDisposable);
            
            _enemyFactory.Create(new CreateEnemyRequest
            {
                EnemyType = enemyType,
                Position = RandomPosition()
            }, enemyDisposable, onDestroyed);
        }

        private void HandleEnemyDestroyed(IDisposable enemyDisposable)
        {
            enemyDisposable.Dispose();
            AddScores();
        }

        private void AddScores()
        {
            _scoresService.AddScores(_enemyContent.DestroyReward);
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
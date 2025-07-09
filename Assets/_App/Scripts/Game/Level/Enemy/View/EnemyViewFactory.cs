using JetBrains.Annotations;
using Tools.Disposable;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Level.Enemy
{
    [UsedImplicitly]
    public class EnemyViewFactory : BaseDisposable
    {
        private readonly EnemyContent _enemyContent;
        private readonly IObjectResolver _objectResolver;
        private readonly IContainerBuilder _containerBuilder;

        public EnemyViewFactory(EnemyContent enemyContent, IObjectResolver objectResolver)
        {
            _enemyContent = enemyContent;
            _objectResolver = objectResolver;
        }
        
        public GameObject Create(EnemyContent.EnemyType enemyType, Vector3 startPosition)
        {
            var go = Object.Instantiate(_enemyContent.ViewPrefab, startPosition, Quaternion.identity);
            if (enemyType == EnemyContent.EnemyType.Patrol) 
                go.AddComponent<EnemyPatrolMover>();

            _objectResolver.InjectGameObject(go);
            return go;
        }
    }
}
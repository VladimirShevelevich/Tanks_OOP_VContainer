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
        
        public GameObject Create(EnemyContent.EnemyType enemyType)
        {
            var go = Object.Instantiate(_enemyContent.ViewPrefab);
            if (enemyType == EnemyContent.EnemyType.Patrol)
            {
                var mover = go.AddComponent<EnemyPatrolMover>();
                //mover.SetContent(_enemyContent);
            }

            _objectResolver.InjectGameObject(go);
            return go;
        }
    }
}
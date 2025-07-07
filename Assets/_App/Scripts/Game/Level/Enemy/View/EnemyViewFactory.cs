using JetBrains.Annotations;
using Tools.Disposable;
using UnityEngine;
using VContainer;

namespace Game.Level.Enemy
{
    [UsedImplicitly]
    public class EnemyViewFactory : BaseDisposable
    {
        private readonly EnemyContent _enemyContent;
        private readonly IContainerBuilder _containerBuilder;

        public EnemyViewFactory(EnemyContent enemyContent)
        {
            _enemyContent = enemyContent;
        }
        
        public GameObject Create(EnemyContent.EnemyType enemyType)
        {
            var go = Object.Instantiate(_enemyContent.ViewPrefab);
            if (enemyType == EnemyContent.EnemyType.Patrol)
            {
                var mover = go.AddComponent<EnemyPatrolMover>();
                mover.SetContent(_enemyContent);
            }

            return go;
        }
    }
}
using System;
using Game.Level.Enemy.Mover;
using JetBrains.Annotations;
using Tools.Disposable;
using VContainer;
using Object = UnityEngine.Object;

namespace Game.Level.Enemy
{
    [UsedImplicitly]
    public class EnemyFactory : BaseDisposable
    {
        private readonly EnemyContent _enemyContent;
        private readonly IObjectResolver _objectResolver;

        public EnemyFactory(EnemyContent enemyContent, IObjectResolver objectResolver)
        {
            _enemyContent = enemyContent;
            _objectResolver = objectResolver;
        }
        
        public Enemy Create(EnemyContent.EnemyType enemyType)
        {
            var view = CreateView();
            var enemy = _objectResolver.Resolve<Enemy>();
            var mover = ResolveMover(enemyType);
            mover.BindView(view);
            enemy.SetMover(mover);
            
            return enemy;
        }        
        
        private EnemyView CreateView()
        {
            var view = Object.Instantiate(_enemyContent.ViewPrefab);
            AddDisposable(new GameObjectDisposer(view.gameObject));
            return view;
        }

        private IEnemyMover ResolveMover(EnemyContent.EnemyType enemyType)
        {
            switch (enemyType)
            {
                case EnemyContent.EnemyType.Static:
                    return _objectResolver.Resolve<EnemyStaticMover>();
                case EnemyContent.EnemyType.Patrol:
                    return _objectResolver.Resolve<EnemyPatrolMover>();
                default:
                    throw new ArgumentOutOfRangeException(nameof(enemyType), enemyType, null);
            }
        }
    }
}
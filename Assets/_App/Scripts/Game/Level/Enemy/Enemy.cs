using JetBrains.Annotations;
using Tools.Disposable;
using UnityEngine;

namespace Game.Level.Enemy
{
    [UsedImplicitly]
    public class Enemy : BaseDisposable
    {
        private readonly EnemyViewFactory _enemyViewFactory;
        private readonly EnemyHealth _enemyHealth;
        private EnemyContent.EnemyType _enemyType;
        private Vector3 _startPosition;

        public Enemy(EnemyViewFactory enemyViewFactory, EnemyHealth enemyHealth)
        {
            _enemyViewFactory = enemyViewFactory;
            _enemyHealth = enemyHealth;
        }

        public void SetType(EnemyContent.EnemyType enemyType)
        {
            _enemyType = enemyType;
        }
        
        public void SetStartPosition(Vector3 startPosition)
        {
            _startPosition = startPosition;
        }

        public void Init()
        {
            CreateView();
        }

        private void CreateView()
        {
            var enemy = _enemyViewFactory.Create(_enemyType, _startPosition);
            AddDisposable(new GameObjectDisposer(enemy.gameObject));
            
            _enemyHealth.BindView(enemy);
        }
    }
}
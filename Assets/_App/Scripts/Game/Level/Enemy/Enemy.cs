using Tools.Disposable;

namespace Game.Level.Enemy
{
    public class Enemy : BaseDisposable
    {
        private readonly EnemyViewFactory _enemyViewFactory;
        private EnemyContent.EnemyType _enemyType;

        public Enemy(EnemyViewFactory enemyViewFactory)
        {
            _enemyViewFactory = enemyViewFactory;
        }

        public void SetType(EnemyContent.EnemyType enemyType)
        {
            _enemyType = enemyType;
        }

        public void Init()
        {
            CreateView();
        }

        private void CreateView()
        {
            var enemy = _enemyViewFactory.Create(_enemyType);
            AddDisposable(new GameObjectDisposer(enemy.gameObject));
        }
    }
}
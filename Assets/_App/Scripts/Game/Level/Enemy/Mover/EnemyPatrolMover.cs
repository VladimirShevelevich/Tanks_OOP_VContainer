using Tools.Disposable;

namespace Game.Level.Enemy.Mover
{
    public class EnemyPatrolMover : BaseDisposable, IEnemyMover
    {
        private readonly EnemyContent _enemyContent;
        private EnemyView _view;

        public EnemyPatrolMover(EnemyContent enemyContent)
        {
            _enemyContent = enemyContent;
        }
        
        public void Init()
        {
            _view.ExecutePatrolMovement(_enemyContent.Movement);
        }

        public void BindView(EnemyView view)
        {
            _view = view;
        }
    }
}
using Game.Level.Enemy.Mover;
using JetBrains.Annotations;
using Tools.Disposable;

namespace Game.Level.Enemy
{
    [UsedImplicitly]
    public class Enemy
    {
        private IEnemyMover _enemyMover;

        public Enemy()
        {
            
        }
        
        public void Init()
        {
            _enemyMover.Init();
        }

        public void SetMover(IEnemyMover mover)
        {
            _enemyMover = mover;
        }
    }
}
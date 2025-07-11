using Tools.Disposable;
using UniRx;
using UnityEngine;

namespace Game.Level.Enemy
{
    public class EnemyLifeTime : BaseDisposable
    {
        private readonly EnemyModel _enemyModel;

        public EnemyLifeTime(EnemyModel enemyModel)
        {
            _enemyModel = enemyModel;
            _enemyModel.Health.Subscribe(OnHealthChanged);
        }

        public void BindView(GameObject enemyView)
        {
            
        }

        private void OnHealthChanged(int newHealth)
        {
            
        }
    }
}
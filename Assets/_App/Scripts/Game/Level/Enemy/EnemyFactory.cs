using Game.Level.Enemy.Requests;
using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Level.Enemy
{
    [UsedImplicitly]
    public class EnemyFactory
    {
        private readonly EnemyContent _enemyContent;
        private readonly IObjectResolver _objectResolver;

        public EnemyFactory(EnemyContent enemyContent, IObjectResolver objectResolver)
        {
            _enemyContent = enemyContent;
            _objectResolver = objectResolver;
        }

        public void Create(CreateEnemyRequest request, CompositeDisposable disposable)
        {
            var model = CreateModel();
            var go = CreateView(request, model, disposable);
            CreateEnemyHealth(go, model, disposable);
        }

        private EnemyModel CreateModel()
        {
            return _objectResolver.Resolve<EnemyModel>();
        }

        private GameObject CreateView(CreateEnemyRequest request, EnemyModel model, CompositeDisposable disposable)
        {
            var go = Object.Instantiate(_enemyContent.ViewPrefab, request.Position, Quaternion.identity);
            if (request.EnemyType == EnemyContent.EnemyType.Patrol)
            {
                go.AddComponent<EnemyPatrolMover>();
            }
            _objectResolver.InjectGameObject(go);
            disposable.Add(new GameObjectDisposer(go));
            return go;
        }

        private void CreateEnemyHealth(GameObject go, EnemyModel model, CompositeDisposable disposable)
        {
            var enemyHealth = _objectResolver.Resolve<EnemyHealth>();
            disposable.Add(enemyHealth);
            enemyHealth.BindModel(model);
            enemyHealth.BindView(go);
        }
    }
}
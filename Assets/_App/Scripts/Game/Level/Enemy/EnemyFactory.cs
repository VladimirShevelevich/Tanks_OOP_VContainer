using Game.Level.Enemy.Requests;
using Game.Level.HealthBar;
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
        private readonly HealthBarFactory _healthBarFactory;
        private readonly IObjectResolver _objectResolver;

        public EnemyFactory(EnemyContent enemyContent, HealthBarFactory healthBarFactory, IObjectResolver objectResolver)
        {
            _enemyContent = enemyContent;
            _healthBarFactory = healthBarFactory;
            _objectResolver = objectResolver;
        }

        public void Create(CreateEnemyRequest request, CompositeDisposable disposer, ReactiveCommand onDestroyed)
        {
            var model = CreateModel();
            var go = CreateView(request, disposer);
            CreateEnemyHealth(go, model, disposer, onDestroyed);
            CreateHealthBar(go.transform, model, disposer);
        }

        private EnemyModel CreateModel()
        {
            return _objectResolver.Resolve<EnemyModel>();
        }

        private GameObject CreateView(CreateEnemyRequest request, CompositeDisposable disposable)
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

        private void CreateEnemyHealth(GameObject go, EnemyModel model, CompositeDisposable disposable, ReactiveCommand onDestroyed)
        {
            var enemyHealth = new EnemyHealth(model, go, onDestroyed);
            disposable.Add(enemyHealth);
        }

        private void CreateHealthBar(Transform targetView, IHealthProvider enemyModel, CompositeDisposable disposer)
        {
            _healthBarFactory.CreateHealthBar(targetView, enemyModel, disposer);
        }
    }
}
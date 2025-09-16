using JetBrains.Annotations;
using Tools.Disposable;
using UnityEngine;

namespace Game.Level.HealthBar
{
    [UsedImplicitly]
    public class HealthBarFactory : BaseDisposable
    {
        private readonly HealthBarContent _healthBarContent;

        public HealthBarFactory(HealthBarContent healthBarContent)
        {
            _healthBarContent = healthBarContent;
        }
        
        public void CreateHealthBar(Transform targetTransform, IHealthProvider healthProvider)
        {
            var view = CreateView(targetTransform);
            CreatePresenter(healthProvider, view);
        }

        private void CreatePresenter(IHealthProvider healthProvider,
            HealthBarView view)
        {
            var presenter = new HealthBarPresenter(view, healthProvider);
            AddDisposable(presenter);
        }

        private HealthBarView CreateView(Transform targetTransform)
        {
            var view = Object.Instantiate(_healthBarContent.ViewPrefab);
            view.SetTargetTransform(targetTransform);
            AddDisposable(new GameObjectDisposer(view.gameObject));
            return view;
        }
    }
}
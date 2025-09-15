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
            var view = CreateView();
            CreatePresenter(targetTransform, healthProvider, view);
        }

        private void CreatePresenter(Transform targetTransform, IHealthProvider healthProvider,
            HealthBarView view)
        {
            var presenter = new HealthBarPresenter(view, targetTransform, healthProvider);
            AddDisposable(presenter);
        }

        private HealthBarView CreateView()
        {
            var view = Object.Instantiate(_healthBarContent.ViewPrefab);
            AddDisposable(new GameObjectDisposer(view.gameObject));
            return view;
        }
    }
}
using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
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
        
        public void CreateHealthBar(Transform targetTransform, IHealthProvider healthProvider, CompositeDisposable disposer)
        {
            var view = CreateView(targetTransform, disposer);
            CreatePresenter(healthProvider, view, disposer);
        }

        private void CreatePresenter(IHealthProvider healthProvider, HealthBarView view, CompositeDisposable disposer)
        {
            var presenter = new HealthBarPresenter(view, healthProvider);
            disposer.Add(presenter);
        }

        private HealthBarView CreateView(Transform targetTransform, CompositeDisposable disposer)
        {
            var view = Object.Instantiate(_healthBarContent.ViewPrefab);
            view.SetTargetTransform(targetTransform);
            disposer.Add(new GameObjectDisposer(view.gameObject));
            return view;
        }
    }
}
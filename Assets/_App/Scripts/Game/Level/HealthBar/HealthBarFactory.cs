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
        
        public void Create()
        {
            var presenter = CreatePresenter();
        }

        private HealthBarPresenter CreatePresenter()
        {
            var view = CreateView();
            return new HealthBarPresenter(view, targetTransform, healthProvider);
        }

        private HealthBarView CreateView()
        {
            var view = Object.Instantiate(_healthBarContent.ViewPrefab);
            AddDisposable(new GameObjectDisposer(view.gameObject));
            return view;
        }
    }
}
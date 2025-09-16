using Tools.Disposable;
using UniRx;
using UnityEngine;

namespace Game.Level.HealthBar
{
    public class HealthBarPresenter : BaseDisposable
    {
        private readonly HealthBarView _view;
        private readonly IHealthProvider _healthProvider;

        public HealthBarPresenter(HealthBarView view, IHealthProvider healthProvider)
        {
            _view = view;
            _healthProvider = healthProvider;

            AddDisposable(healthProvider.CurrentHealth.Subscribe(
                OnHealthUpdate));
        }

        private void OnHealthUpdate(int newHealth)
        {
            var healthRelative = newHealth / _healthProvider.MaxHealth;
            _view.SetValue(healthRelative);
        }
    }
}
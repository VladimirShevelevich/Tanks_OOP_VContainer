using Tools.Disposable;
using UniRx;
using UnityEngine;

namespace Game.Level.HealthBar
{
    public class HealthBarPresenter : BaseDisposable
    {
        private HealthBarView _view;
        private readonly Transform _targetTransform;
        private readonly IHealthProvider _healthProvider;

        public HealthBarPresenter(HealthBarView view, Transform targetTransform, IHealthProvider healthProvider)
        {
            _view = view;
            _targetTransform = targetTransform;
            _healthProvider = healthProvider;

            AddDisposable(healthProvider.CurrentHealth.Subscribe(OnHealthUpdate));
            AddDisposable(Observable.EveryUpdate().Subscribe(_ =>
            {
                OnUpdate();
            }));
        }

        private void OnHealthUpdate(int newHealth)
        {
            var healthRelative = newHealth / _healthProvider.MaxHealth;
            _view.SetValue(healthRelative);
        }

        private void OnUpdate()
        {
            
        }
    }
}
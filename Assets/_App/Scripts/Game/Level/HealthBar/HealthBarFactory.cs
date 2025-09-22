using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;

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
        
        public async UniTaskVoid CreateHealthBar(Transform targetTransform, IHealthProvider healthProvider, CompositeDisposable disposer)
        {
            var view = await CreateViewAsync(targetTransform, disposer);
            if (disposer.IsDisposed)
                return;
            
            CreatePresenter(healthProvider, view, disposer);
        }

        private void CreatePresenter(IHealthProvider healthProvider, HealthBarView view, CompositeDisposable disposer)
        {
            var presenter = new HealthBarPresenter(view, healthProvider);
            disposer.Add(presenter);
        }

        private async UniTask<HealthBarView> CreateViewAsync(Transform targetTransform, CompositeDisposable disposer)
        {
            var operationHandle = Addressables.InstantiateAsync(_healthBarContent.ViewPrefabRef);
            await operationHandle.ToUniTask();
            if (disposer.IsDisposed)
            {
                operationHandle.Release();
                return null;
            }
            
            disposer.Add(new AddressableDisposer(operationHandle));
            var view = operationHandle.Result.GetComponent<HealthBarView>();
            view.SetTargetTransform(targetTransform);
            return view;
        }
    }
}
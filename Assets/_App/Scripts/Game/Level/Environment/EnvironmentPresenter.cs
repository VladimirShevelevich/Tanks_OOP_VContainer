using System;
using Game.Level.Config;
using Tools.Disposable;
using UniRx;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace Game.Level.Environment
{
    public class EnvironmentPresenter : IInitializable, IDisposable
    {
        private readonly LevelConfig _levelConfig;
        private readonly CompositeDisposable _disposable = new();

        public EnvironmentPresenter(LevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
        }
        
        public void Initialize()
        {
            CreateView();
        }

        private void CreateView()
        {
            var view = Object.Instantiate(_levelConfig.EnvironmentViewPrefab);
            _disposable.Add(new GameObjectDisposer(view.gameObject));
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
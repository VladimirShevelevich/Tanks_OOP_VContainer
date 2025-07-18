using System;
using Game.Level.Config;
using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace Game.Level.Environment
{
    [UsedImplicitly]
    public class EnvironmentPresenter : BaseDisposable, IInitializable
    {
        private readonly LevelConfig _levelConfig;

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
            AddDisposable(new GameObjectDisposer(view.gameObject));
        }
    }
}
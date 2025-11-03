using Content;
using Game.Analytics;
using Game.Popups;
using Game.Settings;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private ContentProvider _contentProvider;
        [SerializeField] private Canvas _uiCanvas;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterContent(builder);
            builder.RegisterInstance(_uiCanvas);
            builder.Register<AnalyticsService>(Lifetime.Singleton);
            builder.Register<RemoteContentLoader>(Lifetime.Singleton);
            builder.Register<LevelCreator>(Lifetime.Singleton);

            PopupsInstaller.Install(builder);
            SettingsInstaller.Install(builder);
            
            RegisterInitializable(builder);
        }

        private void RegisterContent(IContainerBuilder builder)
        {
            builder.RegisterInstance(_contentProvider);
            _contentProvider.RegisterContent(builder);
        }

        private void RegisterInitializable(IContainerBuilder builder)
        {
            builder.UseEntryPoints(ep =>
            {
                ep.Add<InitializationQueue>();
            });
        }
    }
}
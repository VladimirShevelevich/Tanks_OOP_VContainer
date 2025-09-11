using Content;
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
            builder.RegisterEntryPoint<LevelCreator>().AsSelf();
        }

        private void RegisterContent(IContainerBuilder builder)
        {
            builder.RegisterInstance(_contentProvider.Levels);
            builder.RegisterInstance(_contentProvider.PlayerContent);
            builder.RegisterInstance(_contentProvider.ProjectileContent);
            builder.RegisterInstance(_contentProvider.EnemyContent);
            builder.RegisterInstance(_contentProvider.HudContent);
            builder.RegisterInstance(_contentProvider.LevelResultUIContent);
            builder.RegisterInstance(_contentProvider.HealthBarContent);
        }
    }
}
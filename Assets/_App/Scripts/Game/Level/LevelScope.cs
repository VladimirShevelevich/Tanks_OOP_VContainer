using Game.Level.Config;
using Game.Level.Enemy;
using Game.Level.Environment;
using Game.Level.HealthBar;
using Game.Level.HUD;
using Game.Level.Input;
using Game.Level.LevelState;
using Game.Level.Player;
using Game.Level.Projectile;
using Game.Level.Scores;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Level
{
    public class LevelScope : LifetimeScope
    {
        [SerializeField] private LevelConfig _levelConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            PlayerInstaller.Install(builder);
            EnemyInstaller.Install(builder);
            HudInstaller.Install(builder);

            builder.RegisterInstance(_levelConfig);
            
            builder.Register<IInputService, StandaloneInputService>(Lifetime.Scoped);
            builder.Register<ProjectileFactory>(Lifetime.Scoped);
            builder.Register<HealthBarFactory>(Lifetime.Scoped);
            builder.Register<ScoresService>(Lifetime.Scoped).AsImplementedInterfaces().AsSelf();
            
            builder.UseEntryPoints(epBuilder =>
            {
                epBuilder.Add<EnvironmentPresenter>().AsSelf();
                epBuilder.Add<LevelStateService>().AsSelf();
            });
        }
    }
}
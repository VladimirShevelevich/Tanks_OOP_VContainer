using Game.Level.Config;
using Game.Level.Enemy;
using Game.Level.Environment;
using Game.Level.Player;
using VContainer;
using VContainer.Unity;

namespace Game.Level
{
    public class LevelScope : LifetimeScope
    {
        private LevelConfig _levelConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            PlayerInstaller.Install(builder);
            EnemyInstaller.Install(builder);
            
            builder.UseEntryPoints(epBuilder =>
            {
                epBuilder.Add<EnvironmentPresenter>();
            });
        }
    }
}
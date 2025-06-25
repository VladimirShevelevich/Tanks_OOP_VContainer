using Game.Level.Config;
using Game.Level.Environment;
using VContainer;
using VContainer.Unity;

namespace Game.Level
{
    public class LevelScope : LifetimeScope
    {
        private LevelConfig _levelConfig;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.UseEntryPoints(epBuilder =>
            {
                epBuilder.Add<EnvironmentPresenter>();
            });
        }
    }
}
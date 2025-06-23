using VContainer;
using VContainer.Unity;

namespace Game
{
    public class GameScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<LevelLoader>();
        }
    }
}
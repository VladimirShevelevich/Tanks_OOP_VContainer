using VContainer;
using VContainer.Unity;

namespace Game.Level.Player
{
    public static class PlayerInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.UseEntryPoints(epBuilder =>
            {
                epBuilder.Add<PlayerService>();
            });

            builder.Register<PlayerFactory>(Lifetime.Scoped);
            builder.Register<PlayerViewFactory>(Lifetime.Scoped);
            
            builder.Register<Player>(Lifetime.Transient);
        }
    }
}
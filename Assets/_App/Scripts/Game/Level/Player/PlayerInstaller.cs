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
                epBuilder.Add<PlayerService>().AsSelf();
            });

            builder.Register<PlayerFactory>(Lifetime.Scoped);
        }
    }
}
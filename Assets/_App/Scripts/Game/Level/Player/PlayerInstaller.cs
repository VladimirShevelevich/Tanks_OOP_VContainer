using VContainer;
using VContainer.Unity;

namespace Player
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
            builder.Register<PlayerMover>(Lifetime.Scoped);
            builder.Register<PlayerShooter>(Lifetime.Scoped);
        }
    }
}
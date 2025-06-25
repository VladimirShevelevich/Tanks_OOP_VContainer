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

            builder.Register<PlayerMover>(Lifetime.Scoped);
        }
    }
}
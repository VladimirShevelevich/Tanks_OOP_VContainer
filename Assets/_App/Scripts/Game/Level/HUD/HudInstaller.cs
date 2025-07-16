using VContainer;
using VContainer.Unity;

namespace Game.Level.HUD
{
    public static class HudInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<HudFactory>(Lifetime.Scoped);
            builder.UseEntryPoints(epBuilder =>
            {
                epBuilder.Add<HudPresenter>();
            });
        }
    }
}
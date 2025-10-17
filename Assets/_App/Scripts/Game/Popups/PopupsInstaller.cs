using VContainer;

namespace Game.Popups
{
    public static class PopupsInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<PopupsService>(Lifetime.Singleton);
            builder.Register<PopupsFactory>(Lifetime.Singleton);
        }
    }
}
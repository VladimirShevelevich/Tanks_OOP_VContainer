using VContainer;

namespace Game.Settings
{
    public static class SettingsInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<SettingsService>(Lifetime.Singleton);
        }
    }
}
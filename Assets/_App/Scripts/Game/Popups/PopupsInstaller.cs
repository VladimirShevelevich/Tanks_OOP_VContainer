using Game.Level.ResultScreen;
using Game.Popups.PopupFactories;
using VContainer;

namespace Game.Popups
{
    public static class PopupsInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<Popups.PopupsService>(Lifetime.Singleton);
            builder.Register<PopupsFactory>(Lifetime.Singleton);

            RegisterFactories(builder);
        }

        private static void RegisterFactories(IContainerBuilder builder)
        {
            builder.Register<WinPopupFactory>(Lifetime.Singleton);
            builder.Register<GameOverPopupFactory>(Lifetime.Singleton);
        }
    }
}
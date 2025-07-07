using VContainer;
using VContainer.Unity;

namespace Game.Level.Enemy
{
    public static class EnemyInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.UseEntryPoints(epBuilder =>
            {
                epBuilder.Add<EnemySpawner>();
            });

            builder.Register<EnemyFactory>(Lifetime.Scoped);
            builder.Register<EnemyViewFactory>(Lifetime.Scoped);
            
            builder.Register<Enemy>(Lifetime.Transient);
        }
    }
}
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
            
            builder.Register<EnemyHealth>(Lifetime.Transient);
            builder.Register<EnemyModel>(Lifetime.Transient);
            builder.Register<EnemyLifeTime>(Lifetime.Transient);
        }
    }
}
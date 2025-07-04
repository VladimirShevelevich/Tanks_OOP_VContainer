using Game.Level.Enemy.Mover;
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
            builder.Register<Enemy>(Lifetime.Transient);

            RegisterMovers(builder);
        }

        private static void RegisterMovers(IContainerBuilder builder)
        {
            builder.Register<EnemyStaticMover>(Lifetime.Transient);
            builder.Register<EnemyPatrolMover>(Lifetime.Transient);
        }
    }
}
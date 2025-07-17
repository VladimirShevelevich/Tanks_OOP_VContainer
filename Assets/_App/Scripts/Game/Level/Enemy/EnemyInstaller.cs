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
                epBuilder.Add<EnemyService>();
            });

            builder.Register<EnemyFactory>(Lifetime.Scoped);
            builder.Register<EnemyModel>(Lifetime.Transient);
        }
    }
}
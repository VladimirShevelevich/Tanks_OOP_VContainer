using Content;
using Game.Level;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class LevelLoader : IInitializable
    {
        private readonly LifetimeScope _gameScope;
        private LevelScope _levelScope;
        private readonly ContentProvider _contentProvider;

        public LevelLoader(LifetimeScope lifetimeScope, ContentProvider contentProvider)
        {
            _gameScope = lifetimeScope;
            _contentProvider = contentProvider;
        }
        
        public void Initialize()
        {
            CreateLevelScope();
        }

        private void CreateLevelScope()
        {
            _levelScope = _gameScope.CreateChild<LevelScope>(builder =>
            {
                builder.RegisterInstance(_contentProvider.Levels[0]);
            });
        }
    }
}
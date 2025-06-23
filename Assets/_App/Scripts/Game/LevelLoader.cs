using Game.Level;
using VContainer.Unity;

namespace Game
{
    public class LevelLoader : IInitializable
    {
        private readonly LifetimeScope _gameScope;

        public LevelLoader(LifetimeScope lifetimeScope)
        {
            _gameScope = lifetimeScope;
        }
        
        public void Initialize()
        {
            CreateLevelScope();
        }

        private void CreateLevelScope()
        {
            var levelScope = _gameScope.CreateChild<LevelScope>();
            //levelScope.Dispose();
        }
    }
}
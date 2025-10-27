using VContainer.Unity;

namespace Game
{
    public class InitializationQueue : IInitializable
    {
        private readonly LevelCreator _levelCreator;

        public InitializationQueue(LevelCreator levelCreator)
        {
            _levelCreator = levelCreator;
        }
        
        public void Initialize()
        {
            
        }
    }
}
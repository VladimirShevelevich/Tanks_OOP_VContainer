using Content;
using JetBrains.Annotations;
using VContainer.Unity;

namespace Game
{
    [UsedImplicitly]
    public class InitializationQueue : IInitializable
    {
        private readonly LevelCreator _levelCreator;
        private readonly RemoteContentLoader _remoteContentLoader;

        public InitializationQueue(LevelCreator levelCreator, RemoteContentLoader remoteContentLoader)
        {
            _levelCreator = levelCreator;
            _remoteContentLoader = remoteContentLoader;
        }
        
        public void Initialize()
        {
            _remoteContentLoader.Load();
        }
    }
}
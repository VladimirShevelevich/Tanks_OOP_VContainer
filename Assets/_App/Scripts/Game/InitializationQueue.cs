using System.Collections.Generic;
using Content;
using Cysharp.Threading.Tasks;
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
        
        public async void Initialize()
        {
            var asyncInitOperations = new List<UniTask>
            {
                InitRemoteContentLoader()
            };

            await UniTask.WhenAll(asyncInitOperations);
            _levelCreator.Initialize();
        }
        
        private async UniTask InitRemoteContentLoader()
        {
            await _remoteContentLoader.LoadAsync();
        }
    }
}
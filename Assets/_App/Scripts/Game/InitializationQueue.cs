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

        public void Initialize()
        {
            InitializeAsync();
        }
        
        private async UniTask InitializeAsync()
        {
            await InitAsyncOperations();
            _levelCreator.Initialize();
        }

        private async UniTask InitAsyncOperations()
        {
            await UniTask.WhenAll(
                InitRemoteContentLoader());
        }
        
        private async UniTask InitRemoteContentLoader()
        {
            await _remoteContentLoader.LoadAsync();
        }
    }
}
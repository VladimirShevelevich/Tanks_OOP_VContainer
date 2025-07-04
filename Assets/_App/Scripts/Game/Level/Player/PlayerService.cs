using JetBrains.Annotations;
using VContainer.Unity;

namespace Player
{
    [UsedImplicitly]
    public class PlayerService : IInitializable
    {
        private readonly PlayerFactory _playerFactory;

        public PlayerService(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }
        
        public void Initialize()
        {
            _playerFactory.CreatePlayer();
        }
    }
}
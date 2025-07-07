using JetBrains.Annotations;
using Tools.Disposable;
using VContainer.Unity;

namespace Game.Level.Player
{
    [UsedImplicitly]
    public class PlayerService : BaseDisposable, IInitializable
    {
        private readonly PlayerFactory _playerFactory;

        public PlayerService(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }
        
        public void Initialize()
        {
           var player = _playerFactory.CreatePlayer();
           player.Init();
           AddDisposable(player);
        }
    }
}
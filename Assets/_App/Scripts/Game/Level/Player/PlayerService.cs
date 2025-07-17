using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
using VContainer.Unity;

namespace Game.Level.Player
{
    [UsedImplicitly]
    public class PlayerService : BaseDisposable, IInitializable
    {
        public IPlayerModel PlayerModel { get; private set; }
        
        private readonly PlayerFactory _playerFactory;
        private readonly PlayerContent _playerContent;

        public PlayerService(PlayerFactory playerFactory, PlayerContent playerContent)
        {
            _playerFactory = playerFactory;
            _playerContent = playerContent;
        }
        
        public void Initialize()
        {
            var model = new PlayerModel(_playerContent.InitialHealth);
            CreatePlayer(model);
            PlayerModel = model;
        }

        private void CreatePlayer(PlayerModel model)
        {
            var playerDisposable = new CompositeDisposable();
            AddDisposable(playerDisposable);
            _playerFactory.CreatePlayer(model, playerDisposable);
        }
    }
}
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

        public PlayerService(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }
        
        public void Initialize()
        {
            var model = new PlayerModel();
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
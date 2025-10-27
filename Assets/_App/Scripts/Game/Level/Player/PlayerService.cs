using System;
using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
using VContainer.Unity;

namespace Game.Level.Player
{
    [UsedImplicitly]
    public class PlayerService : BaseDisposable, IInitializable
    {
        public IObservable<Unit> OnPlayerDeath => _onPlayerDeath;
        private readonly ReactiveCommand _onPlayerDeath = new();
        public IPlayerModel PlayerModel { get; private set; }
        
        private readonly PlayerFactory _playerFactory;
        private readonly PlayerContent _playerBaseContent;

        public PlayerService(PlayerFactory playerFactory, PlayerContent playerContent)
        {
            _playerFactory = playerFactory;
            _playerBaseContent = playerContent;
        }
        
        public void Initialize()
        {
            var model = new PlayerModel(_playerBaseContent.InitialHealth);
            CreatePlayer(model);
            PlayerModel = model;
        }

        private void CreatePlayer(PlayerModel model)
        {
            var playerDisposer = new CompositeDisposable();
            AddDisposable(playerDisposer);
            _playerFactory.CreatePlayer(model, playerDisposer, _onPlayerDeath);
        }
    }
}
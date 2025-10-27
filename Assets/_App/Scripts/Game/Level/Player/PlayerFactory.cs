using JetBrains.Annotations;
using Tools.Disposable;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Level.Player
{
    [UsedImplicitly]
    public class PlayerFactory
    {
        private readonly IObjectResolver _objectResolver;
        private readonly PlayerContent _playerBaseContent;

        public PlayerFactory(IObjectResolver objectResolver, PlayerContent playerContent)
        {
            _objectResolver = objectResolver;
            _playerBaseContent = playerContent;
        }

        public void CreatePlayer(PlayerModel playerModel, CompositeDisposable playerDisposer, ReactiveCommand onPlayerDeath)
        {
            var go = CreateView(playerModel);
            CreatePlayerHealth(go, playerModel, playerDisposer, onPlayerDeath);
            playerDisposer.Add(new GameObjectDisposer(go));
        }

        private GameObject CreateView(PlayerModel playerModel)
        {
            var view = Object.Instantiate(_playerBaseContent.ViewPrefab);
            _objectResolver.InjectGameObject(view);
            view.GetComponent<PlayerMover>().BindModel(playerModel);
            return view;
        }        
        
        private void CreatePlayerHealth(GameObject go, PlayerModel model, CompositeDisposable disposer, ReactiveCommand onPlayerDeath)
        {
            var playerHealth = new PlayerHealth(model, go, onPlayerDeath);
            disposer.Add(playerHealth);
        }
    }
}
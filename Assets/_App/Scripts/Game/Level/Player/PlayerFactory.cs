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
        private readonly PlayerContent _playerContent;

        public PlayerFactory(IObjectResolver objectResolver, PlayerContent playerContent)
        {
            _objectResolver = objectResolver;
            _playerContent = playerContent;
        }

        public void CreatePlayer(PlayerModel playerModel, CompositeDisposable disposable)
        {
            var go = CreateView(playerModel);
            disposable.Add(new GameObjectDisposer(go));
        }

        private GameObject CreateView(PlayerModel playerModel)
        {
            var view = Object.Instantiate(_playerContent.ViewPrefab);
            _objectResolver.InjectGameObject(view);
            view.GetComponent<PlayerMover>().BindModel(playerModel);
            return view;
        }
    }
}
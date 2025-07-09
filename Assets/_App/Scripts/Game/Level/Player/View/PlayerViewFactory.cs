using Tools.Disposable;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Level.Player
{
    public class PlayerViewFactory
    {
        private readonly PlayerContent _playerContent;
        private readonly IObjectResolver _objectResolver;

        public PlayerViewFactory(PlayerContent playerContent, IObjectResolver objectResolver)
        {
            _playerContent = playerContent;
            _objectResolver = objectResolver;
        }

        public GameObject CreateView()
        {
            var view = Object.Instantiate(_playerContent.ViewPrefab);
            _objectResolver.InjectGameObject(view);
            return view;
        }
    }
}
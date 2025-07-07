using Tools.Disposable;
using UnityEngine;

namespace Game.Level.Player
{
    public class PlayerViewFactory
    {
        private readonly PlayerContent _playerContent;

        public PlayerViewFactory(PlayerContent playerContent)
        {
            _playerContent = playerContent;
        }

        public GameObject CreateView()
        {
            var view = Object.Instantiate(_playerContent.ViewPrefab);
            view.GetComponent<PlayerMover>().SetPlayerContent(_playerContent);
            return view;
        }
    }
}
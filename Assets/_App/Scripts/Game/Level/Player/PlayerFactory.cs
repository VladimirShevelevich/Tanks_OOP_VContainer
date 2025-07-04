using JetBrains.Annotations;
using Tools.Disposable;
using UnityEngine;
using VContainer;

namespace Game.Level.Player
{
    [UsedImplicitly]
    public class PlayerFactory : BaseDisposable
    {
        private readonly PlayerContent _playerContent;
        private readonly IObjectResolver _objectResolver;

        public PlayerFactory(PlayerContent playerContent, IObjectResolver objectResolver)
        {
            _playerContent = playerContent;
            _objectResolver = objectResolver;
        }
        
        public void CreatePlayer()
        {
            var view = CreateView();
            CreateMover(view);
            CreateShooter(view);
        }

        private void CreateShooter(PlayerView view)
        {
            var shootingController = _objectResolver.Resolve<PlayerShooter>();
            shootingController.BindView(view);
            AddDisposable(shootingController);
        }

        private void CreateMover(PlayerView view)
        {
            var mover = _objectResolver.Resolve<PlayerMover>();
            mover.BindView(view);
            AddDisposable(mover);
        }

        private PlayerView CreateView()
        {
            var view = Object.Instantiate(_playerContent.ViewPrefab);
            view.BindPlayerContent(_playerContent);
            AddDisposable(new GameObjectDisposer(view.gameObject));
            return view;
        }
    }
}
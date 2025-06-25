using R3;
using Tools.Disposable;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Player
{
    public class PlayerService : IInitializable
    {
        private readonly PlayerContent _playerContent;
        private readonly CompositeDisposable _disposable = new();
        private readonly IObjectResolver _objectResolver;

        public PlayerService(PlayerContent playerContent, IObjectResolver objectResolver)
        {
            _playerContent = playerContent;
            _objectResolver = objectResolver;
        }
        
        public void Initialize()
        {
            var view = CreateView();
            var mover = _objectResolver.Resolve<PlayerMover>();
            mover.BindView(view);
            mover.Initialize();
            mover.AddTo(_disposable);
        }

        private PlayerView CreateView()
        {
            var view = Object.Instantiate(_playerContent.ViewPrefab);
            _disposable.Add(new GameObjectDisposer(view.gameObject));
            return view;
        }
    }
}
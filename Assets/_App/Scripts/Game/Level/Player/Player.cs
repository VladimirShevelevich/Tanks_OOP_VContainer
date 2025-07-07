using JetBrains.Annotations;
using Tools.Disposable;

namespace Game.Level.Player
{
    [UsedImplicitly]
    public class Player : BaseDisposable
    {
        private readonly PlayerViewFactory _playerViewFactory;

        public Player(PlayerViewFactory playerViewFactory)
        {
            _playerViewFactory = playerViewFactory;
        }

        public void Init()
        {
            CreateView();
        }

        private void CreateView()
        {
            var view = _playerViewFactory.CreateView();
            AddDisposable(new GameObjectDisposer(view));
        }
    }
}
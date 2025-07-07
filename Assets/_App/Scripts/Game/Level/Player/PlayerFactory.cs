using JetBrains.Annotations;
using VContainer;

namespace Game.Level.Player
{
    [UsedImplicitly]
    public class PlayerFactory
    {
        private readonly IObjectResolver _objectResolver;

        public PlayerFactory(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        public Player CreatePlayer()
        {
            return _objectResolver.Resolve<Player>();
        }
    }
}
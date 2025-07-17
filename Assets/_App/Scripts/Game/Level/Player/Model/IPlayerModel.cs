using UniRx;
using UnityEngine;

namespace Game.Level.Player
{
    public interface IPlayerModel
    {
        public Vector3 CurrentPosition { get; }
        public IReadOnlyReactiveProperty<int> CurrentHealth { get; }
    }
}
using UnityEngine;

namespace Game.Level.Player
{
    public class PlayerModel : IPlayerModel
    {
        public Vector3 CurrentPosition => _currentPosition;
        private Vector3 _currentPosition;

        public void UpdatePosition(Vector3 newPosition)
        {
            _currentPosition = newPosition;
        }
    }
}
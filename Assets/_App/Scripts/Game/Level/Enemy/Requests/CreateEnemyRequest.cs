using UnityEngine;

namespace Game.Level.Enemy.Requests
{
    public struct CreateEnemyRequest
    {
        public EnemyContent.EnemyType EnemyType;
        public Vector3 Position;
    }
}
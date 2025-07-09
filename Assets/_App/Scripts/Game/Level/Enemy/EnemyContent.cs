using System;
using UnityEngine;

namespace Game.Level.Enemy
{
    [CreateAssetMenu(fileName = "EnemyContent", menuName = "Content/Enemy")]
    public class EnemyContent : ScriptableObject
    {
        public enum EnemyType
        {
            Static,
            Patrol
        }

        [Serializable]
        public class MovementContent
        {
            [field: SerializeField] public Vector2 PatrolRange { get; private set; }
            [field: SerializeField] public float PatrolWaitTime { get; private set; }
            [field: SerializeField] public float Speed { get; private set; }
        }

        [field: SerializeField] public GameObject ViewPrefab { get; private set; }
        [field: SerializeField] public MovementContent Movement { get; private set; }
        [field: SerializeField] public Vector2 SpawnArea { get; private set; }
    }
}
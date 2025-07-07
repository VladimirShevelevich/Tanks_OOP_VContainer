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
            [field: SerializeField] public float PatrolRange { get; private set; }
            [field: SerializeField] public float Speed { get; private set; }
        }

        [field: SerializeField] public GameObject ViewPrefab { get; private set; }
        [field: SerializeField] public MovementContent Movement { get; private set; }
    }
}
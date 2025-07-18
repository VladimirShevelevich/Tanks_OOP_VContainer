using System;
using UnityEngine;

namespace Game.Level.Enemy
{
    [CreateAssetMenu(fileName = "EnemyContent", menuName = "Content/Enemy")]
    public class EnemyContent : ScriptableObject
    {
        [field: SerializeField] public int InitialHealth { get; private set; }
        [field: SerializeField] public int SpawnInterval { get; private set; }

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
        
        [Serializable]
        public class ShootingContent
        {
            [field: SerializeField] public float ShootingInterval { get; private set; }
            [field: SerializeField] public float TowerRotationSpeed { get; private set; }
        }

        [field: SerializeField] public GameObject ViewPrefab { get; private set; }
        [field: SerializeField] public MovementContent Movement { get; private set; }
        [field: SerializeField] public ShootingContent Shooting { get; private set; }
        [field: SerializeField] public Vector2 SpawnArea { get; private set; }
        [field: SerializeField] public int DestroyReward { get; private set; }
    }
}
using Game.Level.Player.Projectile;
using UnityEngine;

namespace Game.Level.Player
{
    [CreateAssetMenu(fileName = "PlayerContent", menuName = "Content/Player")]
    public class PlayerContent : ScriptableObject
    {
        [field: SerializeField] public PlayerView ViewPrefab { get; private set; }
        [field: SerializeField] public float Speed { get; set; }
        [field: SerializeField] public float RotationSpeed { get; set; }
    }
}
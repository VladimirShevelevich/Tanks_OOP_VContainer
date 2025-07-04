using UnityEngine;

namespace Game.Level.Player.Projectile
{
    [CreateAssetMenu(fileName = "ProjectileContent", menuName = "Content/Projectile")]
    public class ProjectileContent : ScriptableObject
    {
        [field: SerializeField] public ProjectileView ProjectilePrefab { get; private set; }
        [field: SerializeField] public float Speed { get; set; }
    }
}
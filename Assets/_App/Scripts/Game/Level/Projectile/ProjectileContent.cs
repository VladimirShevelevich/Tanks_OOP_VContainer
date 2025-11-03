using Content;
using UnityEngine;

namespace Game.Level.Projectile
{
    [CreateAssetMenu(fileName = "ProjectileContent", menuName = "Content/Projectile")]
    public class ProjectileContent : BaseContent
    {
        [field: SerializeField] public ProjectileView ProjectilePrefab { get; private set; }
        [field: SerializeField] public float Speed { get; set; }
    }
}
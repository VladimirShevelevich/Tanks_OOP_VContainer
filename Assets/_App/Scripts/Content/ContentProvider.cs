using Game.Level.Config;
using Game.Level.Player;
using Game.Level.Player.Projectile;
using UnityEngine;

namespace Content
{
    [CreateAssetMenu(fileName = "ContentProvider", menuName = "Content/ContentProvider")]
    public class ContentProvider : ScriptableObject
    {
        [field: SerializeField] public LevelConfig[] Levels { get; private set; }
        [field: SerializeField] public PlayerContent PlayerContent { get; private set; }
        [field: SerializeField] public ProjectileContent ProjectileContent { get; private set; }
    }
}
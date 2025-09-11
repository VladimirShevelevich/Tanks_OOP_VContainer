using Game.Level;
using Game.Level.Enemy;
using Game.Level.HealthBar;
using Game.Level.HUD;
using Game.Level.Player;
using Game.Level.Projectile;
using Game.Level.ResultScreen;
using UnityEngine;

namespace Content
{
    [CreateAssetMenu(fileName = "ContentProvider", menuName = "Content/ContentProvider")]
    public class ContentProvider : ScriptableObject
    {
        [field: SerializeField] public LevelScope[] Levels { get; private set; }
        [field: SerializeField] public PlayerContent PlayerContent { get; private set; }
        [field: SerializeField] public ProjectileContent ProjectileContent { get; private set; }
        [field: SerializeField] public EnemyContent EnemyContent { get; private set; }
        [field: SerializeField] public HudContent HudContent { get; private set; }
        [field: SerializeField] public LevelResultUIContent LevelResultUIContent { get; private set; }
        [field: SerializeField] public HealthBarContent HealthBarContent { get; private set; }
    }
}
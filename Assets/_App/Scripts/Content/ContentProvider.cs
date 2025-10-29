using System.Collections.Generic;
using System.Linq;
using Game.Level;
using Game.Level.Enemy;
using Game.Level.HealthBar;
using Game.Level.HUD;
using Game.Level.Player;
using Game.Level.Projectile;
using Game.Popups;
using UnityEngine;

namespace Content
{
    [CreateAssetMenu(fileName = "ContentProvider", menuName = "Content/ContentProvider")]
    public class ContentProvider : ScriptableObject
    {
        [field: SerializeField] public LevelScope[] Levels { get; private set; }
        [field: SerializeField] public PlayerContent PlayerContent { get; set; }
        [field: SerializeField] public ProjectileContent ProjectileContent { get; private set; }
        [field: SerializeField] public EnemyContent EnemyContent { get; private set; }
        [field: SerializeField] public HudContent HudContent { get; private set; }
        [field: SerializeField] public PopupsContent PopupsContent { get; private set; }
        [field: SerializeField] public HealthBarContent HealthBarContent { get; private set; }

        public void ApplyRemoteContent(Dictionary<string, string> remoteContent)
        {
            PlayerContent.ApplyRemoteContent(remoteContent);
        }
        
    }
}
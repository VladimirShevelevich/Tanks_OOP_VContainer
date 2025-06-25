using Game.Level.Config;
using Player;
using UnityEngine;

namespace Content
{
    [CreateAssetMenu(fileName = "ContentProvider", menuName = "Content/ContentProvider")]
    public class ContentProvider : ScriptableObject
    {
        [field: SerializeField] public LevelConfig[] Levels { get; private set; }
        [field: SerializeField] public PlayerContent PlayerContent { get; private set; }
    }
}
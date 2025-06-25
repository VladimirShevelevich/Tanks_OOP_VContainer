using Game.Level.Environment;
using UnityEngine;

namespace Game.Level.Config
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Content/Level")]
    public class LevelConfig : ScriptableObject
    {
        public EnvironmentView EnvironmentViewPrefab;
    }
}
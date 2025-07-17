using Game.Level.Environment;
using UnityEngine;

namespace Game.Level.Config
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Content/Level")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public EnvironmentView EnvironmentViewPrefab { get; private set; }
        [field: SerializeField] public int ScoreGoal { get; private set; }
    }
}
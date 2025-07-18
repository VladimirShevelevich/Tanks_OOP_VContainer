using UnityEngine;

namespace Game.Level.ResultScreen
{
    [CreateAssetMenu(fileName = "LevelResultUI", menuName = "Content/LevelResultUI")]
    public class LevelResultUIContent : ScriptableObject
    {
        [field: SerializeField] public WinScreen WinScreenPrefab { get; private set; }
        [field: SerializeField] public GameOverScreen GameOverScreenPrefab { get; private set; }
    }
}
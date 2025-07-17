using UnityEngine;

namespace Game.Level.Player
{
    [CreateAssetMenu(fileName = "PlayerContent", menuName = "Content/Player")]
    public class PlayerContent : ScriptableObject
    {
        [field: SerializeField] public GameObject ViewPrefab { get; private set; }
        [field: SerializeField] public float Speed { get; set; }
        [field: SerializeField] public float RotationSpeed { get; set; }
        [field: SerializeField] public int InitialHealth { get; set; }
    }
}
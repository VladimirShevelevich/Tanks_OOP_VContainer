using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerContent", menuName = "Content/Player")]
    public class PlayerContent : ScriptableObject
    {
        [field: SerializeField] public PlayerView ViewPrefab { get; private set; }
        [field: SerializeField] public float Speed { get; set; }
    }
}
using UnityEngine;

namespace Game.Level.HUD
{
    [CreateAssetMenu(fileName = "HudContent", menuName = "Content/HUD")]
    public class HudContent : ScriptableObject
    {
        [field: SerializeField] public GameObject HudPrefab { get; private set; }
    }
}
using UnityEngine;

namespace Game.Level.ResultScreen
{
    [CreateAssetMenu(fileName = "PopupsContent", menuName = "Content/Popups")]
    public class PopupsContent : ScriptableObject
    {
        [field: SerializeField] public WinPopupView WinPopupViewPrefab { get; private set; }
        [field: SerializeField] public GameOverPopupView GameOverPopupViewPrefab { get; private set; }
    }
}
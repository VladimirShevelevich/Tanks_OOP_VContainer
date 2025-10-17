using System;
using Game.Level.LevelState;
using UnityEngine;

namespace Game.Popups
{
    [CreateAssetMenu(fileName = "PopupsContent", menuName = "Content/Popups")]
    public class PopupsContent : ScriptableObject
    {
        [SerializeField] private WinPopup WinPopupPrefab;
        [SerializeField] private GameOverPopup GameOverPopupPrefab;

        public Popup PopupByType(PopupType popupType)
        {
            return popupType switch
            {
                PopupType.Win => WinPopupPrefab,
                PopupType.GameOver => GameOverPopupPrefab,
                _ => throw new ArgumentOutOfRangeException(nameof(popupType), popupType, null)
            };
        }
    }
}
using System;
using Game.Level.LevelState;
using Game.Settings;
using UnityEngine;

namespace Game.Popups
{
    [CreateAssetMenu(fileName = "PopupsContent", menuName = "Content/Popups")]
    public class PopupsContent : ScriptableObject
    {
        [SerializeField] private WinPopup WinPopupPrefab;
        [SerializeField] private GameOverPopup GameOverPopupPrefab;
        [SerializeField] private SettingsPopup SettingsPopupPrefab;

        public Popup PopupByType(PopupType popupType)
        {
            return popupType switch
            {
                PopupType.Win => WinPopupPrefab,
                PopupType.GameOver => GameOverPopupPrefab,
                PopupType.Settings => SettingsPopupPrefab,
                _ => throw new ArgumentOutOfRangeException(nameof(popupType), popupType, null)
            };
        }
    }
}
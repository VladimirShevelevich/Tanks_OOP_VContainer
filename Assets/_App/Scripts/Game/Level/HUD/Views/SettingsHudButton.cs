using System;
using Game.Settings;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.Level.HUD.Views
{
    public class SettingsHudButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private SettingsService _settingsService;

        [Inject]
        public void Construct(SettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        
        private void Start()
        {
            _button.OnClickAsObservable().Subscribe(_ => 
                OnClick()).
                AddTo(gameObject);
        }

        private void OnClick()
        {
            OpenSettingsPopup();
        }

        private void OpenSettingsPopup()
        {
            _settingsService.OpenSettingsPopup();
        }
    }
}